using Volo.Abp.Modularity;

namespace Rumi;

/* Inherit from this class for your domain layer tests. */
public abstract class RumiDomainTestBase<TStartupModule> : RumiTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
