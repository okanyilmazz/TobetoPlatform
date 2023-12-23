using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityConfigurations;

public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
{
    public void Configure(EntityTypeBuilder<Lesson> builder)
    {
        builder.ToTable("Lessons").HasKey(l => l.Id);
        builder.Property(l => l.LanguageId).HasColumnName("LanguageId").IsRequired();
        builder.Property(l => l.LessonSubCategoryId).HasColumnName("LessonSubCategoryId").IsRequired();
        builder.Property(l => l.LessonSubTypeId).HasColumnName("LessonSubTypeId").IsRequired();
        builder.Property(l => l.ProductionCompanyId).HasColumnName("ProductionCompanyId").IsRequired();
        builder.Property(l => l.Name).HasColumnName("Name").IsRequired();
        builder.Property(l => l.StartDate).HasColumnName("StartDate").IsRequired();
        builder.Property(l => l.EndDate).HasColumnName("EndDate").IsRequired();
        builder.Property(l => l.Duration).HasColumnName("Duration").IsRequired();
        builder.HasIndex(indexExpression: l => l.Name, name: "UK_Name").IsUnique();
        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);

        //builder.HasMany(e => e.EducationPrograms)
        //    .WithMany(e => e.Lessons)
        //    .UsingEntity<EducationProgramLesson>();
    }
}
