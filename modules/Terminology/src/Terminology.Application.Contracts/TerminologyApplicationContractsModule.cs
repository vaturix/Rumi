using Volo.Abp.Application;
using Volo.Abp.Authorization;
using Volo.Abp.Modularity;

namespace Terminology;

[DependsOn(
    typeof(TerminologyDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationAbstractionsModule)
    )]
public class TerminologyApplicationContractsModule : AbpModule
{

}
