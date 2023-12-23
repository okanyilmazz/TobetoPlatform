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
    public class AccountAnswerConfiguration : IEntityTypeConfiguration<AccountAnswer>
    {
        public void Configure(EntityTypeBuilder<AccountAnswer> builder)
        {
            builder.ToTable("AccountAnswers").HasKey(b => b.Id);
            builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
            builder.HasIndex(indexExpression: a => a.Id, name: "UK_Id").IsUnique();
            builder.Property(a => a.AccountId).HasColumnName("AccountId").IsRequired();
            builder.HasIndex(indexExpression: a => a.AccountId, name: "UK_AccountId").IsUnique();
            builder.Property(a => a.ExamId).HasColumnName("ExamId").IsRequired();
            builder.HasIndex(indexExpression: a => a.ExamId, name: "UK_ExamId").IsUnique();
            builder.Property(a => a.QuestionId).HasColumnName("QuestionId").IsRequired();
            builder.HasIndex(indexExpression: a => a.QuestionId, name: "UK_QuestionId").IsUnique();

            builder.HasQueryFilter(a => !a.DeletedDate.HasValue);

            builder.HasOne(a=>a.Account);
            builder.HasOne(a=>a.Exam);
            builder.HasOne(a=>a.Question);
        }
    }
}