using System;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations
{
    public class QuestionTypeConfiguration : IEntityTypeConfiguration<QuestionType>
    {
        public void Configure(EntityTypeBuilder<QuestionType> builder)
        {
            builder.ToTable("QuestionTypes").HasKey(q => q.Id);
            builder.Property(q => q.Id).HasColumnName("Id").IsRequired();
            builder.Property(q => q.Name).HasColumnName("Name").IsRequired();
            builder.HasIndex(indexExpression: q => q.Name, name: "UK_Name").IsUnique();
            builder.HasQueryFilter(q => !q.DeletedDate.HasValue);

            builder.HasMany(q => q.Questions)
            .WithOne(qt => qt.QuestionType)
            .HasForeignKey(q => q.QuestionTypeId);
        }
    }
}

