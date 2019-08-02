using System.Threading.Tasks;

namespace LazyCMS.Data
{
    public interface ILazyCMSDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
