using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace LazyCMS.HttpApi.Client.ConsoleTestApp
{
    [DependsOn(
        typeof(LazyCMSHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class LazyCMSConsoleApiClientModule : AbpModule
    {
        
    }
}
