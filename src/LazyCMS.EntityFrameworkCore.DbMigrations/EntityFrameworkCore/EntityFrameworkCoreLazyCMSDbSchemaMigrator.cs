using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LazyCMS.Data;
using Volo.Abp.DependencyInjection;

namespace LazyCMS.EntityFrameworkCore
{
    [Dependency(ReplaceServices = true)]
    public class EntityFrameworkCoreLazyCMSDbSchemaMigrator 
        : ILazyCMSDbSchemaMigrator, ITransientDependency
    {
        private readonly LazyCMSMigrationsDbContext _dbContext;

        public EntityFrameworkCoreLazyCMSDbSchemaMigrator(LazyCMSMigrationsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task MigrateAsync()
        {
            await _dbContext.Database.MigrateAsync();
        }
    }
}