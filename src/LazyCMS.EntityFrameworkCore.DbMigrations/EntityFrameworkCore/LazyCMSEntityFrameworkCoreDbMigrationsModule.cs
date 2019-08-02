using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace LazyCMS.EntityFrameworkCore
{
    [DependsOn(
        typeof(LazyCMSEntityFrameworkCoreModule)
        )]
    public class LazyCMSEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<LazyCMSMigrationsDbContext>();
        }
    }
}
