using Volo.Abp.Modularity;

namespace Terminology;

/* Inherit from this class for your domain layer tests.
 * See SampleManager_Tests for example.
 */
public abstract class TerminologyDomainTestBase<TStartupModule> : TerminologyTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
