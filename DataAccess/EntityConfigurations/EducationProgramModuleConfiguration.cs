using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class EducationProgramModuleConfiguration : IEntityTypeConfiguration<EducationProgramModule>
{
    public void Configure(EntityTypeBuilder<EducationProgramModule> builder)
    {
        builder.ToTable("EducationProgramModules").HasKey(epm => epm.Id);

        builder.Property(epm => epm.Id).HasColumnName("Id").IsRequired();
        builder.Property(epm => epm.EducationProgramId).HasColumnName("EducationProgramId").IsRequired();
        builder.Property(epm => epm.ModuleId).HasColumnName("ModuleId").IsRequired();

        builder.HasIndex(indexExpression: epm => epm.Id, name: "UK_Id").IsUnique();

        builder.HasOne(ap => ap.Module)
               .WithMany(p => p.EducationProgramModules)
               .HasForeignKey(ap => ap.ModuleId);

        builder.HasOne(ap => ap.EducationProgram)
           .WithMany(p => p.EducationProgramModules)
           .HasForeignKey(ap => ap.EducationProgramId);

        builder.HasQueryFilter(c => !c.DeletedDate.HasValue);
    }
}
