﻿using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.Account;
using Volo.Abp.Identity;
using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Modularity;
using Volo.Abp.AuditLogging;
using Volo.Abp.Gdpr;
using Volo.Abp.LanguageManagement;
using Volo.Abp.OpenIddict;
using Volo.Saas.Host;

namespace Rumi;

[DependsOn(
    typeof(RumiDomainModule),
    typeof(RumiApplicationContractsModule),
    typeof(AbpPermissionManagementApplicationModule),
    typeof(AbpFeatureManagementApplicationModule),
    typeof(AbpIdentityApplicationModule),
    typeof(AbpAccountPublicApplicationModule),
    typeof(AbpAccountAdminApplicationModule),
    typeof(SaasHostApplicationModule),
    typeof(AbpAuditLoggingApplicationModule),
    typeof(AbpOpenIddictProApplicationModule),
    typeof(LanguageManagementApplicationModule),
    typeof(AbpGdprApplicationModule),
    typeof(AbpSettingManagementApplicationModule)
    )]
public class RumiApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<RumiApplicationModule>();
        });
    }
}
