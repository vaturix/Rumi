using Volo.Abp.Modularity;

namespace Terminology;

/* Inherit from this class for your application layer tests.
 * See SampleAppService_Tests for example.
 */
public abstract class TerminologyApplicationTestBase<TStartupModule> : TerminologyTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
