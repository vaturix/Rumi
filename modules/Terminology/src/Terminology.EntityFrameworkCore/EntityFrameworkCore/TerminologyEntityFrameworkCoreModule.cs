using Terminology.Terms;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Terminology.EntityFrameworkCore;

[DependsOn(
    typeof(TerminologyDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class TerminologyEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<TerminologyDbContext>(options =>
        {
            /* Add custom repositories here. Example:
             * options.AddRepository<Question, EfCoreQuestionRepository>();
             */
            options.AddRepository<Term, Terms.EfCoreTermRepository>();

        });
    }
}