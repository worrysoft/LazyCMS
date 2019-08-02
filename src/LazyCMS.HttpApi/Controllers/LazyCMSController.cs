using LazyCMS.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace LazyCMS.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class LazyCMSController : AbpController
    {
        protected LazyCMSController()
        {
            LocalizationResource = typeof(LazyCMSResource);
        }
    }
}