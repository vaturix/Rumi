using Rumi.Localization;
using Volo.Abp.Application.Services;

namespace Rumi;

/* Inherit your application services from this class.
 */
public abstract class RumiAppService : ApplicationService
{
    protected RumiAppService()
    {
        LocalizationResource = typeof(RumiResource);
    }
}
