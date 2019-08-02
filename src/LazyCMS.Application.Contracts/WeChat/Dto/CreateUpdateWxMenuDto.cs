using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LazyCMS.WeChat
{
    public class CreateUpdateWxMenuDto
    {
        /// <summary>
        /// 菜单名称
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        /// <summary>
        /// 子菜单
        /// </summary>
        [Required]
        public List<CreateUpdateWxSubmenuDto> Submenus { get; set; }
    }
}
