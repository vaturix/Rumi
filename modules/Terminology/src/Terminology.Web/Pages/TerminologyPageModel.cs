using Terminology.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Terminology.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class TerminologyPageModel : AbpPageModel
{
    protected TerminologyPageModel()
    {
        LocalizationResourceType = typeof(TerminologyResource);
        ObjectMapperContext = typeof(TerminologyWebModule);
    }
}
