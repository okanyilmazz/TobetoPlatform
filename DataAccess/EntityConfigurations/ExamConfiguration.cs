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
    public class ExamConfiguration : IEntityTypeConfiguration<Exam>
    {
        public void Configure(EntityTypeBuilder<Exam> builder)
        {
            builder.ToTable("Exams").HasKey(b => b.Id);
            builder.Property(b => b.Name).HasColumnName("Name").IsRequired();

            builder.HasMany(e => e.Questions)
                .WithMany(e => e.Exams)
                .UsingEntity<ExamQuestion>();

            builder.HasMany(e => e.QuestionTypes)
                .WithMany(e => e.Exams)
                .UsingEntity<ExamQuestionType>();

            builder.HasMany(e => e.OccupationClasses)
                .WithMany(e => e.Exams)
                .UsingEntity<ExamOccupationClass>();
            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }
    }
}
