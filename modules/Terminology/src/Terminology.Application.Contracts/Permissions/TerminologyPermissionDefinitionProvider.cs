using Terminology.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Terminology.Permissions;

public class TerminologyPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(TerminologyPermissions.GroupName, L("Permission:Terminology"));

        var termPermission = myGroup.AddPermission(TerminologyPermissions.Terms.Default, L("Permission:Terms"));
        termPermission.AddChild(TerminologyPermissions.Terms.Create, L("Permission:Create"));
        termPermission.AddChild(TerminologyPermissions.Terms.Edit, L("Permission:Edit"));
        termPermission.AddChild(TerminologyPermissions.Terms.Delete, L("Permission:Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<TerminologyResource>(name);
    }
}