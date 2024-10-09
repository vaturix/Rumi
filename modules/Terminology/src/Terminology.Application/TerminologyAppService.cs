using Terminology.Localization;
using Volo.Abp.Application.Services;

namespace Terminology;

public abstract class TerminologyAppService : ApplicationService
{
    protected TerminologyAppService()
    {
        LocalizationResource = typeof(TerminologyResource);
        ObjectMapperContext = typeof(TerminologyApplicationModule);
    }
}
