using LazyCMS.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace LazyCMS.WeChat
{
    /// <summary>
    /// 微信用户信息
    /// </summary>
    public class WxUser : AuditedAggregateRoot<Guid>,
        IAutoBuildEntity //自定义的自动构建实体接口
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public virtual Guid UserId { get; protected set; }
        /// <summary>
        /// 用户实体导航
        /// </summary>
        [ForeignKey("UserId")]
        public virtual Users.AppUser User { get; protected set; }
        /// <summary>
        /// 公众号openId
        /// </summary>
        [StringLength(100)]
        public string PublicOpenId { get; protected set; }
        /// <summary>
        /// 小程序openId
        /// </summary>
        [StringLength(100)]
        public string AppletOpenId { get; protected set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsEnable { get; protected set; }

        protected WxUser()
        {

        }

        public WxUser(Guid userId)
        {
            //User = new Users.AppUser(userId, "18328408303");
        }

        /// <summary>
        /// 设置状态
        /// </summary>
        /// <param name="_isEnable"></param>
        public void SetEnableState(bool _isEnable)
        {
            this.IsEnable = _isEnable;
        }

        /// <summary>
        /// 更新公众号openId
        /// </summary>
        /// <param name="_openId"></param>
        public void UpdatePublicOpenId(string _openId)
        {
            this.PublicOpenId = _openId;
        }

        /// <summary>
        /// 更新小程序openId
        /// </summary>
        /// <param name="_openId"></param>
        public void UpdateAppletOpenId(string _openId)
        {
            this.AppletOpenId = _openId;
        }
    }
}
