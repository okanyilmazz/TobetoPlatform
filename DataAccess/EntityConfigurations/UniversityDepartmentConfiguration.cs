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
    public class UniversityDepartmentConfiguration : IEntityTypeConfiguration<UniversityDepartment>
    {
        public void Configure(EntityTypeBuilder<UniversityDepartment> builder)
        {
            builder.ToTable("UniversityDepartment").HasKey(a => a.Id);
            builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
            builder.Property(a => a.Name).HasColumnName("Name").IsRequired();
            builder.HasIndex(indexExpression: a => a.Name, name: "UK_Name").IsUnique();
            builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
        }
    }
}
