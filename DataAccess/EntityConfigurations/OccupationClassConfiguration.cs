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
    public class OccupationClassConfiguration : IEntityTypeConfiguration<OccupationClass>

    {
        public void Configure(EntityTypeBuilder<OccupationClass> builder)
        {
            builder.ToTable("OccupationClasses").HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("Id").IsRequired();
            builder.Property(p => p.Name).HasColumnName("Name").IsRequired();
            builder.HasIndex(indexExpression: p => p.Name, name: "UK_Name").IsUnique();
            builder.HasQueryFilter(p => !p.DeletedDate.HasValue);

            builder.HasMany(p => p.EducationPrograms)
                .WithMany(P => P.OccupationClasses)
                .UsingEntity<EducationProgramOccupationClass>();
                
           builder.HasMany(p => p.EducationPrograms)
                  .WithMany(P => P.OccupationClasses)
                  .UsingEntity<EducationProgramOccupationClass>();

             builder.HasMany(p => p.Exams)
                .WithMany(P => P.OccupationClasses)
                .UsingEntity<ExamOccupationClass>();

            builder.HasMany(p => p.Accounts)
                 .WithMany(P => P.OccupationClasses)
                 .UsingEntity<AccountOccupationClass>();

            builder.HasMany(p => p.Surveys)
                 .WithMany(P => P.OccupationClasses)
                  .UsingEntity<AccountOccupationClass>();
        }
    }
}