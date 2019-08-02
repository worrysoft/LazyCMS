using LazyCMS.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace LazyCMS.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class LazyCMSPageModel : AbpPageModel
    {
        protected LazyCMSPageModel()
        {
            LocalizationResourceType = typeof(LazyCMSResource);
        }
    }
}