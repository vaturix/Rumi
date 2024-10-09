using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Terminology;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(TerminologyHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class TerminologyConsoleApiClientModule : AbpModule
{

}
