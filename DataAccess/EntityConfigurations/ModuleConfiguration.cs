using Core.Entities;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class ModuleConfiguration : IEntityTypeConfiguration<Module>
{
    public void Configure(EntityTypeBuilder<Module> builder)
    {
        builder.ToTable("Modules").HasKey(m => m.Id);

        builder.Property(m => m.Id).HasColumnName("Id").IsRequired();
        builder.Property(m => m.Name).HasColumnName("Name").IsRequired();
        builder.Property(m => m.ParentId).HasColumnName("ParentId");

        builder.HasIndex(indexExpression: l => l.Id, name: "UK_Id").IsUnique();

        builder.HasMany(m => m.Children)
            .WithOne(m=>m.Parent).HasForeignKey(m => m.ParentId)
           .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(m => m.EducationProgramModules);
        builder.HasMany(m => m.LessonModules);


        builder.HasQueryFilter(c => !c.DeletedDate.HasValue);
    }
}
