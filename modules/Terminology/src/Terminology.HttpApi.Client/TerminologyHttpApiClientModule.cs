using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Terminology;

[DependsOn(
    typeof(TerminologyApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class TerminologyHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(TerminologyApplicationContractsModule).Assembly,
            TerminologyRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<TerminologyHttpApiClientModule>();
        });
    }
}
