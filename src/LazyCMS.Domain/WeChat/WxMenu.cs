using LazyCMS.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace LazyCMS.WeChat
{
    /// <summary>
    /// 微信菜单(聚合根)
    /// </summary>
    public class WxMenu : FullAuditedAggregateRoot<Guid>,
        IAutoBuildEntity //自定义的自动构建实体接口
    {
        /// <summary>
        /// 菜单名称
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Name { get; protected set; }
        /// <summary>
        /// 子菜单
        /// </summary>
        public virtual ICollection<WxSubmenu> Submenus { get; protected set; }

        public virtual WxUser WxUser { get; protected set; }

        protected WxMenu()
        {

        }
    }
}
