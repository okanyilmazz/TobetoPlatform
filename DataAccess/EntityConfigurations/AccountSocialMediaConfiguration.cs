using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace DataAccess.EntityConfigurations;

public class AccountSocialMediaConfiguration : IEntityTypeConfiguration<AccountSocialMedia>
{
    public void Configure(EntityTypeBuilder<AccountSocialMedia> builder)
    {
        builder.ToTable("AccountSocialMedias");
        builder.Property(s => s.Id).HasColumnName("Id").IsRequired();
        builder.Property(s => s.AccountId).HasColumnName("AccountId").IsRequired();
        builder.Property(s => s.SocialMediaId).HasColumnName("SocialMediaId").IsRequired();
        builder.Property(s => s.Url).HasColumnName("Url").IsRequired();
        builder.HasQueryFilter(s => !s.DeletedDate.HasValue);

    }
}
