using Senparc.NeuChar.Context;
using Senparc.NeuChar.Entities;
using Senparc.Weixin.MP.Entities.Request;
using Senparc.Weixin.MP.MessageHandlers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LazyCMS.Web.Handlers
{
    /// <summary>
    /// 微信公众号消息处理器
    /// </summary>
    public class WxMPMessageHandler : MessageHandler<WxMPMessageContext>
    {
        public WxMPMessageHandler(Stream inputStream, PostModel postModel)
             : base(inputStream, postModel)
        {

        }

        /// <summary>
        /// 默认返回消息
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override IResponseMessageBase DefaultResponseMessage(IRequestMessageBase requestMessage)
        {
            throw new NotImplementedException();
        }
    }

    public class WxMPMessageContext : MessageContext<IRequestMessageBase, IResponseMessageBase>
    {
        public WxMPMessageContext()
        {
            base.MessageContextRemoved += WxMPMessageContext_MessageContextRemoved;
        }

        private void WxMPMessageContext_MessageContextRemoved(object sender, WeixinContextRemovedEventArgs<IRequestMessageBase, IResponseMessageBase> e)
        {
            /* 注意，这个事件不是实时触发的（当然你也可以专门写一个线程监控）
             * 为了提高效率，根据WeixinContext中的算法，这里的过期消息会在过期后下一条请求执行之前被清除
             */

            var messageContext = e.MessageContext as WxMPMessageContext;
            if (messageContext == null)
            {
                return;//如果是正常的调用，messageContext不会为null
            }

            //TODO:这里根据需要执行消息过期时候的逻辑，下面的代码仅供参考

            //Log.InfoFormat("{0}的消息上下文已过期",e.OpenId);
            //api.SendMessage(e.OpenId, "由于长时间未搭理客服，您的客服状态已退出！");
        }
    }
}
