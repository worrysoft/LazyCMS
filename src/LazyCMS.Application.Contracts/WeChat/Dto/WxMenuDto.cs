using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace LazyCMS.WeChat
{
    /// <summary>
    /// 微信公众号菜单dto
    /// </summary>
    public class WxMenuDto : AuditedEntityDto<Guid>
    {
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 子菜单
        /// </summary>
        public List<WxSubmenuDto> Submenus { get; set; }
    }
}
