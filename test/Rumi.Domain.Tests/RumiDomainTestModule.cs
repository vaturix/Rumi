using Volo.Abp.Modularity;

namespace Rumi;

[DependsOn(
    typeof(RumiDomainModule),
    typeof(RumiTestBaseModule)
)]
public class RumiDomainTestModule : AbpModule
{

}
