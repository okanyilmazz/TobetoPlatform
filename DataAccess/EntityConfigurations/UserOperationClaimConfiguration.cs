using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class UserOperationClaimConfiguration : IEntityTypeConfiguration<UserOperationClaim>
{
    public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
    {

        builder.ToTable("UserOperationClaims").Ignore(u => u.Id);
        builder.HasKey(uop => new { uop.UserId, uop.OperationClaimId });

        builder.Property(u => u.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(u => u.OperationClaimId).HasColumnName("OperationClaimId").IsRequired();

        builder.HasQueryFilter(u => !u.DeletedDate.HasValue);

        builder.HasOne(uop => uop.User)
            .WithMany(uop => uop.UserOperationClaims)
            .HasForeignKey(uop => uop.UserId);

        builder.HasOne(uop => uop.OperationClaim)
           .WithMany(uop => uop.UserOperationClaims)
           .HasForeignKey(uop => uop.OperationClaimId);
    }
} 
