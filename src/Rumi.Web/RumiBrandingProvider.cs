using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;
using Microsoft.Extensions.Localization;
using Rumi.Localization;

namespace Rumi.Web;

[Dependency(ReplaceServices = true)]
public class RumiBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<RumiResource> _localizer;

    public RumiBrandingProvider(IStringLocalizer<RumiResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
