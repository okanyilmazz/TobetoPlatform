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
        builder.ToTable("Lessons").HasKey(c => c.Id);
        builder.HasIndex(indexExpression: c => c.Name, name: "UK_Name").IsUnique();
        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);

        //builder.HasMany(e => e.EducationPrograms)
        //    .WithMany(e => e.Lessons)
        //    .UsingEntity<EducationProgramLesson>();
    }
}
