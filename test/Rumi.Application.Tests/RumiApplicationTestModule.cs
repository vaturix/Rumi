using Volo.Abp.Modularity;

namespace Rumi;

[DependsOn(
    typeof(RumiApplicationModule),
    typeof(RumiDomainTestModule)
)]
public class RumiApplicationTestModule : AbpModule
{

}
