using System;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations
{
    public class ExamResultConfiguration : IEntityTypeConfiguration<ExamResult>
    {
        public void Configure(EntityTypeBuilder<ExamResult> builder)
        {
            builder.ToTable("ExamResults").HasKey(r => r.Id);
            //Eğer tabloda languageId olsaydı languageId yazılacaktı.
            builder.Property(r => r.Id).HasColumnName("Id").IsRequired();

            builder.HasQueryFilter(q => !q.DeletedDate.HasValue);
        }
    }
}

