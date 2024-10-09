using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using Terminology.Localization;
using Terminology.Web.Menus;
using Volo.Abp.AspNetCore.Mvc.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;
using Volo.Abp.VirtualFileSystem;
using Terminology.Permissions;

namespace Terminology.Web;

[DependsOn(
    typeof(TerminologyApplicationContractsModule),
    typeof(AbpAspNetCoreMvcUiThemeSharedModule),
    typeof(AbpAutoMapperModule)
    )]
public class TerminologyWebModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
        {
            options.AddAssemblyResource(typeof(TerminologyResource), typeof(TerminologyWebModule).Assembly);
        });

        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(TerminologyWebModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpNavigationOptions>(options =>
        {
            options.MenuContributors.Add(new TerminologyMenuContributor());
        });

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<TerminologyWebModule>();
        });

        context.Services.AddAutoMapperObjectMapper<TerminologyWebModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<TerminologyWebModule>(validate: true);
        });

        Configure<RazorPagesOptions>(options =>
        {
            //Configure authorization.
            options.Conventions.AuthorizePage("/Terms/Index", TerminologyPermissions.Terms.Default);
        });
    }
}