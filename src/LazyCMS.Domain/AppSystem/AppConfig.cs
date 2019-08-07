using LazyCMS.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;

namespace LazyCMS.AppSystem
{
    /// <summary>
    /// 应用配置
    /// </summary>
    public class AppConfig : AuditedEntity<int>,
        IAutoBuildEntity //自定义的自动构建实体接口
    {
        /// <summary>
        /// 配置键
        /// </summary>
        [Required]
        public string ItemKey { get; protected set; }
        /// <summary>
        /// 配置值
        /// </summary>
        [Required]
        public string ItemValue { get; protected set; }

        protected AppConfig()
        { }
    }
}
