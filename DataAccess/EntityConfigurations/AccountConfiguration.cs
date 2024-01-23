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
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Accounts").HasKey(a => a.Id);

            builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
            builder.Property(a => a.AddressId).HasColumnName("AddressId").IsRequired();
            builder.Property(a => a.UserId).HasColumnName("UserId").IsRequired();
            builder.Property(a => a.PhoneNumber).HasColumnName("PhoneNumber").IsRequired();
            builder.Property(a => a.NationalId).HasColumnName("NationalId").IsRequired();
            builder.Property(a => a.Description).HasColumnName("Description").IsRequired();
            builder.Property(a => a.BirthDate).HasColumnName("BirthDate").IsRequired();
            builder.Property(a => a.ProfilePhotoPath).HasColumnName("ProfilePhotoPath");

            builder.HasIndex(indexExpression: a => a.Id, name: "UK_Id").IsUnique();
            builder.HasIndex(indexExpression: a => a.AddressId, name: "UK_AddressId").IsUnique();
            builder.HasIndex(indexExpression: a => a.UserId, name: "UK_UserId").IsUnique();
            builder.HasIndex(indexExpression: a => a.PhoneNumber, name: "UK_PhoneNumber").IsUnique();

            builder.HasOne(a => a.Address);
            builder.HasOne(a => a.User);

            builder.HasMany(au => au.AccountUniversities);
            builder.HasMany(al => al.AccountLanguages);
            builder.HasMany(asm => asm.AccountSocialMedias);
            builder.HasMany(ah => ah.AccountHomeworks);
            builder.HasMany(al => al.AccountLessons);
            builder.HasMany(aoc => aoc.AccountOccupationClasses);
            builder.HasMany(ase => ase.AccountSessions);
            builder.HasMany(ask => ask.AccountSkills);
            builder.HasMany(ask => ask.AccountEducationPrograms);
            builder.HasMany(we => we.WorkExperiences);
            builder.HasMany(c => c.Certificates);



            builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
        }
    }
}
