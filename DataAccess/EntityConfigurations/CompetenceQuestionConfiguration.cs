using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class CompetenceQuestionConfiguration : IEntityTypeConfiguration<CompetenceQuestion>
{
    public void Configure(EntityTypeBuilder<CompetenceQuestion> builder)
    {
        builder.ToTable("CompetenceQuestions").HasKey(cq => cq.Id);

        builder.Property(cq => cq.Id).HasColumnName("Id").IsRequired();
        builder.Property(cq => cq.CompetenceCategoryId).HasColumnName("CompetenceId").IsRequired();
        builder.Property(cq => cq.Question).HasColumnName("Question").IsRequired();
        builder.Property(cq => cq.MaxOption).HasColumnName("MaxOption").IsRequired();

        builder.HasQueryFilter(cq => !cq.DeletedDate.HasValue);
    }
}
