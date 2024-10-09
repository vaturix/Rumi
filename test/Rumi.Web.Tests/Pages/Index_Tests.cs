using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Rumi.Pages;

[Collection(RumiTestConsts.CollectionDefinitionName)]
public class Index_Tests : RumiWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
