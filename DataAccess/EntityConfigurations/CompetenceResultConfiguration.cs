using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class CompetenceResultConfiguration : IEntityTypeConfiguration<CompetenceResult>
{
    public void Configure(EntityTypeBuilder<CompetenceResult> builder)
    {
        builder.ToTable("CompetenceResults").HasKey(cr => cr.Id);

        builder.Property(cr => cr.Id).HasColumnName("Id").IsRequired();
        builder.Property(cr => cr.CompetenceCategoryId).HasColumnName("CompetenceId").IsRequired();
        builder.Property(cr => cr.AccountId).HasColumnName("AccountId").IsRequired();
        builder.Property(cr => cr.Point).HasColumnName("Point").IsRequired();

        builder.HasQueryFilter(cr => !cr.DeletedDate.HasValue);
    }
}
