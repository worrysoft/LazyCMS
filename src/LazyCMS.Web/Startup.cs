using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Senparc.CO2NET;
using Senparc.CO2NET.Cache;
using Senparc.CO2NET.Cache.Memcached;
using Senparc.CO2NET.RegisterServices;
using Senparc.Weixin;
using Senparc.Weixin.Cache.Memcached;
using Senparc.Weixin.Entities;
using Senparc.Weixin.RegisterServices;
using Volo.Abp;

namespace LazyCMS.Web
{
    public class Startup
    {
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddApplication<LazyCMSWebModule>(options =>
            {
                options.UseAutofac();
            });

            services.AddSenparcGlobalServices(services.GetConfiguration()) //Senparc.CO2NET 全局注册
                .AddSenparcWeixinServices(services.GetConfiguration()); //Senparc.Weixin 注册

            return services.BuildServiceProviderFromFactory();
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory,
            IHostingEnvironment env, IOptions<SenparcSetting> senparcSetting, IOptions<SenparcWeixinSetting> senparcWeixinSetting)
        {
            app.InitializeApplication();

            // 启动 CO2NET 全局注册，必须！
            IRegisterService register = RegisterService.Start(env, senparcSetting.Value)
                //关于 UseSenparcGlobal() 的更多用法见 CO2NET Demo：https://github.com/Senparc/Senparc.CO2NET/blob/master/Sample/Senparc.CO2NET.Sample.netcore/Startup.cs
                .UseSenparcGlobal();

            #region 配置和使用 Memcached      -- DPBMARK Memcached

            //配置Memcached缓存（按需，独立）
            var memcachedConfigurationStr = senparcSetting.Value.Cache_Memcached_Configuration;
            var useMemcached = !string.IsNullOrEmpty(memcachedConfigurationStr) && memcachedConfigurationStr != "#{Cache_Memcached_Configuration}#";

            if (useMemcached) //这里为了方便不同环境的开发者进行配置，做成了判断的方式，实际开发环境一般是确定的，这里的if条件可以忽略
            {
                app.UseEnyimMemcached();

                /* 说明：
                * 1、Memcached 的连接字符串信息会从 Config.SenparcSetting.Cache_Memcached_Configuration 自动获取并注册，如不需要修改，下方方法可以忽略
               /* 2、如需手动修改，可以通过下方 SetConfigurationOption 方法手动设置 Memcached 链接信息（仅修改配置，不立即启用）
                */
                Senparc.CO2NET.Cache.Memcached.Register.SetConfigurationOption(memcachedConfigurationStr);

                //以下会立即将全局缓存设置为 Memcached
                Senparc.CO2NET.Cache.Memcached.Register.UseMemcachedNow();

                //也可以通过以下方式自定义当前需要启用的缓存策略
                CacheStrategyFactory.RegisterObjectCacheStrategy(() => MemcachedObjectCacheStrategy.Instance);
            }

            #endregion

            #region 注册日志（按需，建议）

            register.RegisterTraceLog(ConfigTraceLog);//配置TraceLog

            #endregion

            #region 微信配置

            /* 微信配置开始
             * 
             * 建议按照以下顺序进行注册，尤其须将缓存放在第一位！
             */

            //注册开始

            #region 微信缓存（按需，必须在 register.UseSenparcWeixin() 之前）
            // 微信的 Memcached 缓存，如果不使用则注释掉（开启前必须保证配置有效，否则会抛错）    -- DPBMARK Memcached
            if (useMemcached)
            {
                app.UseSenparcWeixinCacheMemcached();
            }                                                                                      // DPBMARK_END

            #endregion

            //开始注册微信信息，必须！
            register.UseSenparcWeixin(senparcWeixinSetting.Value, senparcSetting.Value);

            #endregion
        }

        /// <summary>
        /// 配置微信跟踪日志
        /// </summary>
        private void ConfigTraceLog()
        {
            //这里设为Debug状态时，/App_Data/WeixinTraceLog/目录下会生成日志文件记录所有的API请求日志，正式发布版本建议关闭

            //如果全局的IsDebug（Senparc.CO2NET.Config.IsDebug）为false，此处可以单独设置true，否则自动为true
            Senparc.CO2NET.Trace.SenparcTrace.SendCustomLog("系统日志", "系统启动");//只在Senparc.Weixin.Config.IsDebug = true的情况下生效

            //全局自定义日志记录回调
            Senparc.CO2NET.Trace.SenparcTrace.OnLogFunc = () =>
            {
                //加入每次触发Log后需要执行的代码
            };

            //当发生基于WeixinException的异常时触发
            WeixinTrace.OnWeixinExceptionFunc = ex =>
            {
                //加入每次触发WeixinExceptionLog后需要执行的代码

            };
        }
    }
}
