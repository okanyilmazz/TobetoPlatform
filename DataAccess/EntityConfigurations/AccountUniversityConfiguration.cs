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
        builder.ToTable("AccountUniversities").HasKey(e => e.Id);
        builder.Property(e => e.Id).HasColumnName("Id").IsRequired();
        builder.Property(e => e.AccountId).HasColumnName("AccountId").IsRequired();
        builder.Property(e => e.DegreeTypeId).HasColumnName("DegreeTypeId").IsRequired();
        builder.Property(e => e.UniversityId).HasColumnName("UniversityId").IsRequired();
        builder.Property(e => e.UniversityDepartmentId).HasColumnName("UniversityDepartmentId").IsRequired();
        builder.Property(e => e.StartDate).HasColumnName("StartDate").IsRequired();
        builder.Property(e => e.EndDate).HasColumnName("EndDate");
        builder.Property(e => e.IsEducationActive).HasColumnName("IsEducationActive");
        builder.HasQueryFilter(e => !e.DeletedDate.HasValue);
    }
}
