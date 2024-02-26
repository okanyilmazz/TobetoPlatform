using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class LessonModuleConfiguration : IEntityTypeConfiguration<LessonModule>
{
    public void Configure(EntityTypeBuilder<LessonModule> builder)
    {
        builder.ToTable("LessonModules").HasKey(l => l.Id);

        builder.Property(l => l.Id).HasColumnName("Id").IsRequired();
        builder.Property(l => l.LessonId).HasColumnName("LessonId");
        builder.Property(l => l.ModuleId).HasColumnName("ModuleId");

        builder.HasIndex(indexExpression: l => l.Id, name: "UK_Id").IsUnique();

        builder.HasOne(l => l.Lesson)
            .WithMany(l=>l.LessonModules)
            .HasForeignKey(lm=>lm.LessonId);

        builder.HasOne(l => l.Module)
           .WithMany(l => l.LessonModules)
           .HasForeignKey(lm => lm.ModuleId);

        builder.HasQueryFilter(l => !l.DeletedDate.HasValue);
    }
}