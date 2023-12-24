using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityConfigurations;

public class AccountUniversityConfiguration : IEntityTypeConfiguration<AccountUniversity>
{
    public void Configure(EntityTypeBuilder<AccountUniversity> builder)
    {
        builder.ToTable("AccountUniversities").HasKey(a => a.Id);
        builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
        builder.Property(a => a.AccountId).HasColumnName("AccountId").IsRequired();
        builder.Property(a => a.DegreeTypeId).HasColumnName("DegreeTypeId").IsRequired();
        builder.Property(a => a.UniversityId).HasColumnName("UniversityId").IsRequired();
        builder.Property(a => a.UniversityDepartmentId).HasColumnName("UniversityDepartmentId").IsRequired();
        builder.Property(a => a.StartDate).HasColumnName("StartDate").IsRequired();
        builder.Property(a => a.EndDate).HasColumnName("EndDate");
        builder.Property(a => a.IsEducationActive).HasColumnName("IsEducationActive");
        builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
    }
}
