using Rumi.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Rumi.Web.Pages;

public abstract class RumiPageModel : AbpPageModel
{
    protected RumiPageModel()
    {
        LocalizationResourceType = typeof(RumiResource);
    }
}
