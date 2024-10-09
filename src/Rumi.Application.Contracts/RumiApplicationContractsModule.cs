using Volo.Abp.Account;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
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
    typeof(RumiDomainSharedModule),
    typeof(AbpFeatureManagementApplicationContractsModule),
    typeof(AbpSettingManagementApplicationContractsModule),
    typeof(AbpIdentityApplicationContractsModule),
    typeof(AbpAccountPublicApplicationContractsModule),
    typeof(AbpAccountAdminApplicationContractsModule),
    typeof(SaasHostApplicationContractsModule),
    typeof(AbpAuditLoggingApplicationContractsModule),
    typeof(AbpOpenIddictProApplicationContractsModule),
    typeof(LanguageManagementApplicationContractsModule),
    typeof(AbpGdprApplicationContractsModule),
    typeof(AbpPermissionManagementApplicationContractsModule)
)]
[DependsOn(typeof(TerminologyApplicationContractsModule))]
    public class RumiApplicationContractsModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        RumiDtoExtensions.Configure();
    }
}
