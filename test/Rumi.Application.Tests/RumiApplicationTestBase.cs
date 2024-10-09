using Volo.Abp.Modularity;

namespace Rumi;

public abstract class RumiApplicationTestBase<TStartupModule> : RumiTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
