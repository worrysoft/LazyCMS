using System;
using System.Collections.Generic;
using System.Text;

namespace LazyCMS.WeChat
{
    /// <summary>
    /// 菜单回复类型
    /// </summary>
    public enum MenuReplyType
    {
        /// <summary>
        /// 点击事件
        /// </summary>
        ClickEvent,
        /// <summary>
        /// 跳转网页
        /// </summary>
        JumpPage,
        /// <summary>
        /// 跳转小程序
        /// </summary>
        JumpApplet,
        /// <summary>
        /// 素材消息
        /// </summary>
        MaterialMessage,
        /// <summary>
        /// 其他
        /// </summary>
        Other
    }
}
