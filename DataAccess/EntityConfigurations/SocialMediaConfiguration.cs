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
    public class SocialMediaConfiguration : IEntityTypeConfiguration<SocialMedia>
    {
        public void Configure(EntityTypeBuilder<SocialMedia> builder)
        {
            builder.ToTable("SocialMedias").HasKey(s => s.Id);
            builder.Property(s=>s.Name).HasColumnName("Name");
            builder.Property(s => s.IconPath).HasColumnName("IconPath");
            builder.HasIndex(indexExpression: a => a.Name, name: "UK_Name").IsUnique();

            builder.HasMany(s => s.Accounts)
                .WithMany(s => s.SocialMedias)
                .UsingEntity<AccountSocialMedia>();


            builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
        }
    }
}
