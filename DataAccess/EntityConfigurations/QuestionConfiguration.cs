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
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.ToTable("Questions").HasKey(b => b.Id);
            builder.Property(b => b.CorrectOption).HasColumnName("Description").IsRequired();
            builder.Property(b => b.CorrectOption).HasColumnName("OptionA").IsRequired();
            builder.Property(b => b.CorrectOption).HasColumnName("OptionB").IsRequired();
            builder.Property(b => b.CorrectOption).HasColumnName("OptionC").IsRequired();
            builder.Property(b => b.CorrectOption).HasColumnName("OptionD").IsRequired();
            builder.Property(b => b.CorrectOption).HasColumnName("CorrectOption").IsRequired();

            builder.HasMany(e => e.Exams)
             .WithMany(e => e.Questions)
            .UsingEntity<ExamQuestion>();

            builder.HasOne(qt => qt.QuestionType)
                .WithMany(q => q.Questions)
                .HasForeignKey(q => q.QuestionTypeId);

            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }
    }
}
