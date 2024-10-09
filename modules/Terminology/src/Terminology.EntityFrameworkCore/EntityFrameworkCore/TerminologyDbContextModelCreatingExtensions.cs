using Volo.Abp.EntityFrameworkCore.Modeling;
using Terminology.Terms;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace Terminology.EntityFrameworkCore;

public static class TerminologyDbContextModelCreatingExtensions
{
    public static void ConfigureTerminology(
        this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

        /* Configure all entities here. Example:

        builder.Entity<Question>(b =>
        {
            //Configure table & schema name
            b.ToTable(TerminologyDbProperties.DbTablePrefix + "Questions", TerminologyDbProperties.DbSchema);

            b.ConfigureByConvention();

            //Properties
            b.Property(q => q.Title).IsRequired().HasMaxLength(QuestionConsts.MaxTitleLength);

            //Relations
            b.HasMany(question => question.Tags).WithOne().HasForeignKey(qt => qt.QuestionId);

            //Indexes
            b.HasIndex(q => q.CreationTime);
        });
        */
        if (builder.IsHostDatabase())
        {
            builder.Entity<Term>(b =>
            {
                b.ToTable(TerminologyDbProperties.DbTablePrefix + "Terms", TerminologyDbProperties.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.Name).HasColumnName(nameof(Term.Name));
                b.Property(x => x.Description).HasColumnName(nameof(Term.Description));
            });

        }
    }
}