using Microsoft.AspNetCore.Builder;
using Rumi;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();
await builder.RunAbpModuleAsync<RumiWebTestModule>();

public partial class Program
{
}
