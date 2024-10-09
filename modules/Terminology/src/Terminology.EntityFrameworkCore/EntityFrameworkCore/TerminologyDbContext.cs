using Terminology.Terms;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Terminology.EntityFrameworkCore;

[ConnectionStringName(TerminologyDbProperties.ConnectionStringName)]
public class TerminologyDbContext : AbpDbContext<TerminologyDbContext>, ITerminologyDbContext
{
    public DbSet<Term> Terms { get; set; } = null!;
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public TerminologyDbContext(DbContextOptions<TerminologyDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureTerminology();
    }
}