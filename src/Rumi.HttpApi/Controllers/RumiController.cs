using Rumi.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Rumi.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class RumiController : AbpControllerBase
{
    protected RumiController()
    {
        LocalizationResource = typeof(RumiResource);
    }
}
