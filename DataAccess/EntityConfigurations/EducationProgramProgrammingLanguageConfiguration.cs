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
    public class EducationProgramProgrammingLanguageConfiguration : IEntityTypeConfiguration<EducationProgramProgrammingLanguage>
    {
        public void Configure(EntityTypeBuilder<EducationProgramProgrammingLanguage> builder)
        {
            builder.ToTable("EducationProgramProgrammingLanguages").HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("EducationProgramId").IsRequired();
            builder.Property(e => e.Id).HasColumnName("ProgrammingLanguageId").IsRequired();
            builder.HasQueryFilter(e => !e.DeletedDate.HasValue);
        }
    }
}
