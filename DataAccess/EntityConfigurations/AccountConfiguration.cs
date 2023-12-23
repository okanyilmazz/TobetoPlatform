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
            builder.HasIndex(indexExpression: a => a.Id, name: "UK_Id").IsUnique();
            builder.Property(a => a.AddressId).HasColumnName("AddressId").IsRequired();
            builder.HasIndex(indexExpression: a => a.AddressId, name: "UK_AddressId").IsUnique();
            builder.Property(a => a.UserId).HasColumnName("UserId").IsRequired();
            builder.HasIndex(indexExpression: a => a.UserId, name: "UK_UserId").IsUnique();
            builder.Property(a => a.PhoneNumber).HasColumnName("PhoneNumber").IsRequired();
            builder.HasIndex(indexExpression: a => a.PhoneNumber, name: "UK_PhoneNumber").IsUnique();
            builder.Property(a => a.NationalId).HasColumnName("NationalId").IsRequired();
            builder.Property(a => a.Description).HasColumnName("Description").IsRequired();
            builder.Property(a => a.BirthDate).HasColumnName("BirthDate").IsRequired();
            builder.Property(a => a.ProfilePhotoPath).HasColumnName("ProfilePhotoPath");
            //builder.HasIndex(indexExpression: a => a.ProfilePhotoPath, name: "UK_ProfilePhotoPath").IsUnique();
            builder.HasQueryFilter(a => !a.DeletedDate.HasValue);

            builder.HasOne(u => u.User);
            builder.HasMany(s => s.SocialMedias)
                .WithMany(a => a.Accounts)
                .UsingEntity<AccountSocialMedia>();

            builder.HasMany(o => o.OccupationClasses)
                .WithMany(a => a.Accounts)
                .UsingEntity<AccountOccupationClass>();

            builder.HasMany(s => s.Skills)
                .WithMany(a => a.Accounts)
                .UsingEntity<AccountSkill>();

            builder.HasMany(l => l.Languages)
                .WithMany(a => a.Accounts)
                .UsingEntity<AccountLanguage>();

            builder.HasMany(s => s.Sessions)
                .WithMany(a => a.Accounts)
                .UsingEntity<AccountSession>();

            builder.HasMany(h => h.Homeworks)
                .WithMany(a => a.Accounts)
                .UsingEntity<AccountHomework>();

            builder.HasMany(h => h.Lessons)
               .WithMany(a => a.Accounts)
               .UsingEntity<AccountLesson>();
               
            builder.HasMany(u=>u.Universities)
                .WithMany(a => a.Accounts)
                .UsingEntity<AccountUniversity>();

            builder.HasOne(a => a.Address);
        }
    }
}
