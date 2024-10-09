using Volo.Abp.Modularity;

namespace Terminology;

[DependsOn(
    typeof(TerminologyApplicationModule),
    typeof(TerminologyDomainTestModule)
    )]
public class TerminologyApplicationTestModule : AbpModule
{

}
