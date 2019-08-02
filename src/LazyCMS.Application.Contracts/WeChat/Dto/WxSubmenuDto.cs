using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace LazyCMS.WeChat
{
    /// <summary>
    /// 微信公众号子菜单dto
    /// </summary>
    public class WxSubmenuDto : AuditedEntityDto<Guid>
    {
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 回复类型
        /// </summary>
        public MenuReplyType ReplyType { get; set; }
        /// <summary>
        /// 回复内容
        /// </summary>
        public string ReplyContent { get; set; }
    }
}
