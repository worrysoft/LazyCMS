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
        private readonly IRepository<AppUser, Guid> appUsers;

        public WeChatAppService(IRepository<WxMenu, Guid> _rMenu,
            IRepository<WxUser, Guid> _rUser,
            IRepository<AppUser, Guid> _appUsers)
        {
            this.wxMenus = _rMenu;
            this.wxUsers = _rUser;
            this.appUsers = _appUsers;
        }

        public async Task<bool> CreateWeChatUserAsync(string openId)
        {
            var wxu = wxUsers.WithDetails().Where(t => t.PublicOpenId.Equals(openId)).SingleOrDefault();

            if (wxu == null)
            {
                WxUser m = new WxUser(Guid.Parse("724f85bf-4b4c-fc0b-ee9e-39ef787933c2"));
                m.UpdatePublicOpenId(openId);
                var r = await wxUsers.InsertAsync(m);

                return true;
            }
            return false;
        }
    }
}
