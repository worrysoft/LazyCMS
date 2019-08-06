using LazyCMS.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace LazyCMS.WeChat
{
    /// <summary>
    /// 子菜单
    /// </summary>
    public class WxSubmenu : FullAuditedEntity<Guid>, IAutoBuildEntity
    {
        /// <summary>
        /// 子菜单名称
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Name { get; protected set; }
        /// <summary>
        /// 回复类型
        /// </summary>
        public MenuReplyType ReplyType { get; protected set; }
        /// <summary>
        /// 回复内容
        /// </summary>
        public string ReplyContent { get; protected set; }

        protected WxSubmenu()
        {

        }
    }
}
