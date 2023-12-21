using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityConfigurations
{
    public class EducationProgramConfiguration : IEntityTypeConfiguration<EducationProgram>
    {
        public void Configure(EntityTypeBuilder<EducationProgram> builder)
        {
            builder.ToTable("EducationPrograms").HasKey(e => e.Id);
            builder.HasIndex(indexExpression: e => e.Name, name: "UK_Name").IsUnique();
            builder.HasQueryFilter(e => !e.DeletedDate.HasValue);
            
            builder.HasMany(e => e.ProgrammingLanguages) 
                .WithMany(e => e.EducationPrograms) 
                .UsingEntity<EducationProgramProgrammingLanguage>();

            builder.HasMany(e => e.OccupationClasses)
                .WithMany(e => e.EducationPrograms)
                .UsingEntity<EducationProgramOccupationClass>();

            builder.HasMany(e => e.Lessons)
                .WithMany(e => e.EducationPrograms)
                .UsingEntity<EducationProgramLesson>();


        }
    }
}
