using Volo.Abp.Modularity;

namespace Terminology;

[DependsOn(
    typeof(TerminologyDomainModule),
    typeof(TerminologyTestBaseModule)
)]
public class TerminologyDomainTestModule : AbpModule
{

}
