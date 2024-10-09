using Terminology.Terms;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Terminology.EntityFrameworkCore;

[ConnectionStringName(TerminologyDbProperties.ConnectionStringName)]
public interface ITerminologyDbContext : IEfCoreDbContext
{
    DbSet<Term> Terms { get; set; }
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}