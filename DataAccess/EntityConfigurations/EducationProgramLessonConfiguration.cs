using Entities.Concretes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityConfigurations
{
    public class EducationProgramLessonConfiguration : IEntityTypeConfiguration<EducationProgramLesson>
    {
        public void Configure(EntityTypeBuilder<EducationProgramLesson> builder)
        {
            builder.ToTable("EducationProgramLessons").HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
            builder.HasQueryFilter(c => !c.DeletedDate.HasValue);

        }
    }
}
