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
        }
    }
}
