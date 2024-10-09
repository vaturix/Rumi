using Rumi.Samples;
using Xunit;

namespace Rumi.EntityFrameworkCore.Domains;

[Collection(RumiTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<RumiEntityFrameworkCoreTestModule>
{

}
