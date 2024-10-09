using Xunit;

namespace Rumi.EntityFrameworkCore;

[CollectionDefinition(RumiTestConsts.CollectionDefinitionName)]
public class RumiEntityFrameworkCoreCollection : ICollectionFixture<RumiEntityFrameworkCoreFixture>
{

}
