using Volo.Abp.Modularity;

namespace LazyCMS
{
    [DependsOn(
        typeof(LazyCMSApplicationModule),
        typeof(LazyCMSDomainTestModule)
        )]
    public class LazyCMSApplicationTestModule : AbpModule
    {

    }
}