using System;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class ExamQuestionConfiguration : IEntityTypeConfiguration<ExamQuestion>
{ 
    public void Configure(EntityTypeBuilder<ExamQuestion> builder)
    {
        builder.ToTable("ExamQuestions").HasKey(e => e.Id);
        builder.Property(e => e.Id).HasColumnName("Id").IsRequired();
        builder.Property(e => e.QuestionId).HasColumnName("QuestionId").IsRequired();
        builder.Property(e => e.ExamId).HasColumnName("ExamId").IsRequired();
        builder.HasIndex(indexExpression: e => e.QuestionId, name: "UK_QuestionId").IsUnique();
        builder.HasIndex(indexExpression: e => e.ExamId, name: "UK_ExamId").IsUnique();
        builder.HasQueryFilter(e => !e.DeletedDate.HasValue);
    }
}

