using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Account;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.VirtualFileSystem;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.AuditLogging;
using Volo.Abp.LanguageManagement;
using Volo.Saas.Host;
using Volo.Abp.Gdpr;
using Volo.Abp.OpenIddict;
using Terminology;

namespace Rumi;

[DependsOn(
    typeof(RumiApplicationContractsModule),
    typeof(AbpPermissionManagementHttpApiClientModule),
    typeof(AbpFeatureManagementHttpApiClientModule),
    typeof(AbpIdentityHttpApiClientModule),
    typeof(AbpAccountAdminHttpApiClientModule),
    typeof(AbpAccountPublicHttpApiClientModule),
    typeof(SaasHostHttpApiClientModule),
    typeof(AbpAuditLoggingHttpApiClientModule),
    typeof(AbpOpenIddictProHttpApiClientModule),
    typeof(LanguageManagementHttpApiClientModule),
    typeof(AbpGdprHttpApiClientModule),
    typeof(AbpSettingManagementHttpApiClientModule)
)]
[DependsOn(typeof(TerminologyHttpApiClientModule))]
    public class RumiHttpApiClientModule : AbpModule
{
    public const string RemoteServiceName = "Default";

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(RumiApplicationContractsModule).Assembly,
            RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<RumiHttpApiClientModule>();
        });
    }
}
