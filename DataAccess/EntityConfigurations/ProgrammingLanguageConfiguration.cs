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
    public class ProgrammingLanguageConfiguration : IEntityTypeConfiguration<ProgrammingLanguage>
    {
        public void Configure(EntityTypeBuilder<ProgrammingLanguage> builder)
        {
            builder.ToTable("ProgrammingLanguage").HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("Id").IsRequired();
            builder.Property(p => p.Name).HasColumnName("Name").IsRequired();
            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);

            builder.HasMany(e=>e.EducationPrograms)
                .WithMany(p => p.ProgrammingLanguages)
                .UsingEntity<EducationProgramProgrammingLanguage>();

        }
    }
}
