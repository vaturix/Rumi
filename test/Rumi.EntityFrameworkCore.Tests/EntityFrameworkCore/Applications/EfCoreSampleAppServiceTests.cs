using Rumi.Samples;
using Xunit;

namespace Rumi.EntityFrameworkCore.Applications;

[Collection(RumiTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<RumiEntityFrameworkCoreTestModule>
{

}
