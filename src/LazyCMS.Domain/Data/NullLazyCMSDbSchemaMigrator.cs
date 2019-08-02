using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace LazyCMS.Data
{
    /* This is used if database provider does't define
     * ILazyCMSDbSchemaMigrator implementation.
     */
    public class NullLazyCMSDbSchemaMigrator : ILazyCMSDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}