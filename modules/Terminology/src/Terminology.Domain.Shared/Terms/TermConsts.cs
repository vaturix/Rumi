namespace Terminology.Terms
{
    public static class TermConsts
    {
        private const string DefaultSorting = "{0}Name asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "Term." : string.Empty);
        }

    }
}