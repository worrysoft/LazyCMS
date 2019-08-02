using LazyCMS.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace LazyCMS
{
    [DependsOn(
        typeof(LazyCMSEntityFrameworkCoreTestModule)
        )]
    public class LazyCMSDomainTestModule : AbpModule
    {

    }
}