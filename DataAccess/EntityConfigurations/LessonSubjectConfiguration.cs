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
    public class LessonSubjectConfiguration : IEntityTypeConfiguration<LessonSubject>
    {
        public void Configure(EntityTypeBuilder<LessonSubject> builder)
        {
            builder.ToTable("LessonSubjects").HasKey(c => c.Id);

            builder.Property(l => l.Id).HasColumnName("Id").IsRequired();
            builder.Property(l => l.Name).HasColumnName("Name").IsRequired();

            builder.HasIndex(indexExpression: c => c.Name, name: "UK_Name").IsUnique();
            builder.HasIndex(indexExpression: l => l.Id, name: "UK_Id").IsUnique();

            builder.HasQueryFilter(c => !c.DeletedDate.HasValue);
        }
    }
}
