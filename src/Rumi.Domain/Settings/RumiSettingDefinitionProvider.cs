using Volo.Abp.Settings;

namespace Rumi.Settings;

public class RumiSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(RumiSettings.MySetting1));
    }
}
