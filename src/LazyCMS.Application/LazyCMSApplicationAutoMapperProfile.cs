using AutoMapper;
using LazyCMS.WeChat;

namespace LazyCMS
{
    public class LazyCMSApplicationAutoMapperProfile : Profile
    {
        public LazyCMSApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */

            CreateMap<WxSubmenu, WxSubmenuDto>();
            CreateMap<WxMenu, WxMenuDto>();

            CreateMap<CreateUpdateWxSubmenuDto, WxSubmenu>();
            CreateMap<CreateUpdateWxMenuDto, WxMenu>();
        }
    }
}
