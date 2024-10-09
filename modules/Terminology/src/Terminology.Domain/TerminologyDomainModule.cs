using Volo.Abp.Caching;
using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Terminology;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(AbpCachingModule),
    typeof(TerminologyDomainSharedModule)
)]
public class TerminologyDomainModule : AbpModule
{

}
