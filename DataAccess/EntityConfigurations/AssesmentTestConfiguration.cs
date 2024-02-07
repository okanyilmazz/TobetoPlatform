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
    public class AssesmentTestConfiguration : IEntityTypeConfiguration<AssesmentTest>
    {
        public void Configure(EntityTypeBuilder<AssesmentTest> builder)
        {
            builder.ToTable("AssesmentTests").HasKey(a => a.Id);

            builder.Property(a => a.Name).HasColumnName("Name").IsRequired();
            builder.Property(a => a.Description).HasColumnName("Description").IsRequired();
            builder.Property(a => a.Duration).HasColumnName("Duration").IsRequired();
            builder.Property(a => a.QuestionCount).HasColumnName("QuestionCount").IsRequired();


            builder.HasIndex(indexExpression: a => a.Id, name: "UK_Id").IsUnique();


            builder.HasMany(a => a.AssesmentTestQuestions);
            builder.HasMany(a => a.AssesmentTestOccupationClasses);


            builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
        }
    }
}
