using Localization.Resources.AbpUi;
using Terminology.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Terminology;

[DependsOn(
    typeof(TerminologyApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class TerminologyHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(TerminologyHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<TerminologyResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
