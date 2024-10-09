using Volo.Abp.Reflection;

namespace Terminology.Permissions;

public class TerminologyPermissions
{
    public const string GroupName = "Terminology";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(TerminologyPermissions));
    }

    public static class Terms
    {
        public const string Default = GroupName + ".Terms";
        public const string Edit = Default + ".Edit";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }
}