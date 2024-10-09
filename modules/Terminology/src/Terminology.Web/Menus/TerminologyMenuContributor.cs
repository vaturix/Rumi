using Terminology.Permissions;
using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Terminology.Localization;
using Volo.Abp.Authorization.Permissions;

namespace Terminology.Web.Menus;

public class TerminologyMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name != StandardMenus.Main)
        {
            return;
        }

        var moduleMenu = AddModuleMenuItem(context); //Do not delete `moduleMenu` variable as it will be used by ABP Suite!

        AddMenuItemTerms(context, moduleMenu);
    }

    private static ApplicationMenuItem AddModuleMenuItem(MenuConfigurationContext context)
    {
        var l = context.GetLocalizer<TerminologyResource>();

        var moduleMenu = new ApplicationMenuItem(
            TerminologyMenus.Prefix,
            displayName: l["Menu:Terminology"],
            "~/Terminology",
            icon: "fa fa-globe");

        //Add main menu items.
        context.Menu.Items.AddIfNotContains(moduleMenu);
        return moduleMenu;
    }
    private static void AddMenuItemTerms(MenuConfigurationContext context, ApplicationMenuItem parentMenu)
    {
        parentMenu.AddItem(
            new ApplicationMenuItem(
                Menus.TerminologyMenus.Terms,
                context.GetLocalizer<TerminologyResource>()["Menu:Terms"],
                "/Terminology/Terms",
                icon: "fa fa-file-alt",
                requiredPermissionName: TerminologyPermissions.Terms.Default
            )
        );
    }
}