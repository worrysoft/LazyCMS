using LazyCMS.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace LazyCMS.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(LazyCMSEntityFrameworkCoreDbMigrationsModule),
        typeof(LazyCMSApplicationContractsModule)
        )]
    public class LazyCMSDbMigratorModule : AbpModule
    {
        
    }
}
