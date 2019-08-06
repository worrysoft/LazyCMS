using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp;
using Volo.Abp.Users;
using System.Linq;
using System.Linq.Expressions;
using System;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.EntityFrameworkCore.DependencyInjection;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using System.Reflection;
using Microsoft.Extensions.Options;

namespace LazyCMS.EntityFrameworkCore
{
    public static class LazyCMSDbContextModelCreatingExtensions
    {
        public static void ConfigureLazyCMS<TDependInterface>(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(LazyCMSConsts.DbTablePrefix + "YourEntities", LazyCMSConsts.DbSchema);

            //    //...
            //});

            /*
             * 自动注入实体
             */
            foreach (Type entityType in GetAutoBuildEntities<TDependInterface>())
            {
                builder.Entity(entityType, (b) =>
                {
                    b.ToTable($"{LazyCMSConsts.DbTablePrefix}_{entityType.Name}", LazyCMSConsts.DbSchema); //定义实体映射表名
                    b.TryConfigureAudited();
                    b.TryConfigureFullAudited(); //配置完全日志审核
                    b.TryConfigureExtraProperties(); //配置额外属性
                    b.TryConfigureConcurrencyStamp(); //配置并发时间戳
                });
            }
        }

        /// <summary>
        /// 从当前程序集中注册指定泛型实例
        /// </summary>
        /// <typeparam name="TDependInterface"></typeparam>
        /// <returns></returns>
        private static IEnumerable<Type> GetAutoBuildEntities<TDependInterface>()
        {
            var domainAssemblies = System.AppDomain.CurrentDomain.GetAssemblies().Where(t => t.FullName.StartsWith("LazyCMS."));
            return domainAssemblies.SelectMany(s => s.ExportedTypes).Where(t => typeof(TDependInterface).IsAssignableFrom(t) && t.IsClass && !t.IsAbstract);
        }

        /// <summary>
        /// 动态创建仓储
        /// </summary>
        /// <typeparam name="TDependInterface"></typeparam>
        /// <param name="options"></param>
        public static void ConfigureDynamicRepository<TDependInterface>(this IAbpDbContextRegistrationOptionsBuilder options)
        {
            //反射获取方法
            var AddRepositoryMethod = options.GetType().GetMethod("AddRepository"); // AddRepository
            var EntityMethod = options.GetType().GetMethod("Entity"); // EntityOptions

            foreach (Type entityType in GetAutoBuildEntities<TDependInterface>())
            {
                // 构建实体导航属性自动包含委托
                var call = EntityIncludeBuilder.Instance.Create(entityType);
                EntityMethod.MakeGenericMethod(entityType).Invoke(options, new object[] { call });

                // 获取实体主键类型
                var primaryKeyType = EntityHelper.FindPrimaryKeyType(entityType);

                // 构建实体对应的仓储类型
                Type registerRepository = (primaryKeyType == null ? typeof(EfCoreRepository<,>) : typeof(EfCoreRepository<,,>))
                    .MakeGenericType(typeof(LazyCMSDbContext), entityType, primaryKeyType);

                // 添加实体仓储
                AddRepositoryMethod.MakeGenericMethod(entityType, registerRepository).Invoke(options, null);
            }
        }

        public static void ConfigureCustomUserProperties<TUser>(this EntityTypeBuilder<TUser> b)
            where TUser : class, IUser
        {
            //b.Property<string>(nameof(AppUser.MyProperty))...
        }
    }
}