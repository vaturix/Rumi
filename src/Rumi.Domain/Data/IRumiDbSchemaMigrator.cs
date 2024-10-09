using System.Threading.Tasks;

namespace Rumi.Data;

public interface IRumiDbSchemaMigrator
{
    Task MigrateAsync();
}
