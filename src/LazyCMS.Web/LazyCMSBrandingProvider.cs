using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Components;
using Volo.Abp.DependencyInjection;

namespace LazyCMS.Web
{
    [Dependency(ReplaceServices = true)]
    public class LazyCMSBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "LazyCMS";
    }
}
