using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using LazyCMS.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace LazyCMS.Web.Pages
{
    /* Inherit your UI Pages from this class. To do that, add this line to your Pages (.cshtml files under the Page folder):
     * @inherits LazyCMS.Web.Pages.LazyCMSPage
     */
    public abstract class LazyCMSPage : AbpPage
    {
        [RazorInject]
        public IHtmlLocalizer<LazyCMSResource> L { get; set; }
    }
}
