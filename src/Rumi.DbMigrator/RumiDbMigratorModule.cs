using Rumi.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Rumi.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(RumiEntityFrameworkCoreModule),
    typeof(RumiApplicationContractsModule)
)]
public class RumiDbMigratorModule : AbpModule
{
}
