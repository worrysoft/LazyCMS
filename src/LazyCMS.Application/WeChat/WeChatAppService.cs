using LazyCMS.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;

namespace LazyCMS.WeChat
{
    /// <summary>
    /// 微信应用服务
    /// </summary>
    public class WeChatAppService : LazyCMSAppService
    {
        private readonly IRepository<WxMenu, Guid> wxMenus;
        private readonly IRepository<WxUser, Guid> wxUsers;
        private readonly IRepository<Volo.Abp.Identity.IdentityUser, Guid> identityUsers;

        public WeChatAppService(IRepository<WxMenu, Guid> _rMenu,
            IRepository<WxUser, Guid> _rUser,
            IRepository<Volo.Abp.Identity.IdentityUser, Guid> _identityUsers)
        {
            this.wxMenus = _rMenu;
            this.wxUsers = _rUser;
            this.identityUsers = _identityUsers;
        }

        public async Task<WxUser> CreateGetOrAddAsync(string openId)
        {
            var wxu = wxUsers.WithDetails().Where(t => t.PublicOpenId.Equals(openId)).SingleOrDefault();

            if (wxu == null)
            {
                Guid uid = Guid.NewGuid();
                await this.identityUsers.InsertAsync(new Volo.Abp.Identity.IdentityUser(uid, "测试微信用户"));

                WxUser m = new WxUser(uid);
                m.UpdatePublicOpenId(openId);
                await wxUsers.InsertAsync(m);

                return m;
            }

            return wxu;
        }
    }
}
