using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LazyCMS.Web.Handlers;
using Microsoft.AspNetCore.Mvc;
using Senparc.Weixin.MP;
using Senparc.Weixin.MP.MvcExtension;
using Volo.Abp.AspNetCore.Mvc;

namespace LazyCMS.Web.Controllers
{
    public class WeChatController : AbpController
    {
        [HttpGet]
        [ActionName("Index")]
        public IActionResult GetAction(string signature, string timestamp, string nonce, string echostr)
        {
            if (CheckSignature.Check(signature, timestamp, nonce, Senparc.Weixin.Config.SenparcWeixinSetting.Token))
            {
                return Content(echostr); //返回随机字符串则表示验证通过
            }
            else
            {
                return Content($"failed:{signature},{CheckSignature.GetSignature(timestamp, nonce, Senparc.Weixin.Config.SenparcWeixinSetting.Token)}。如果您在浏览器中看到这条信息，表明此Url可以填入微信后台。");
            }
        }

        [HttpPost]
        [ActionName("Index")]
        public IActionResult PostAction(Senparc.Weixin.MP.Entities.Request.PostModel postModel)
        {
            if (!CheckSignature.Check(postModel.Signature, postModel.Timestamp, postModel.Nonce, Senparc.Weixin.Config.SenparcWeixinSetting.Token))
            {
                return Content("参数错误！");
            }

            postModel.Token = Senparc.Weixin.Config.SenparcWeixinSetting.Token;//根据自己后台的设置保持一致
            postModel.EncodingAESKey = Senparc.Weixin.Config.SenparcWeixinSetting.EncodingAESKey;//根据自己后台的设置保持一致
            postModel.AppId = Senparc.Weixin.Config.SenparcWeixinSetting.WeixinAppId;//根据自己后台的设置保持一致

            //自定义MessageHandler，对微信请求的详细判断操作都在这里面。
            var messageHandler = new WxMPMessageHandler(Request.Body, postModel);//接收消息
            messageHandler.OmitRepeatedMessage = true;//启用消息去重功能
            messageHandler.Execute();//执行微信处理过程

            return new FixWeixinBugWeixinResult(messageHandler);//返回结果
        }
    }
}