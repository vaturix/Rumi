using Terminology.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Terminology;

public abstract class TerminologyController : AbpControllerBase
{
    protected TerminologyController()
    {
        LocalizationResource = typeof(TerminologyResource);
    }
}
