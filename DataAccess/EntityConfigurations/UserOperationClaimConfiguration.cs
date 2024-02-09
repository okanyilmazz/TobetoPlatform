using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityConfigurations
{
    public class UserOperationClaimConfiguration : IEntityTypeConfiguration<UserOperationClaim>
    {
        public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
        {

            builder.ToTable("UserOperationClaims").HasKey(u => u.Id);

            builder.Property(u => u.UserId).HasColumnName("UserId").IsRequired();
            builder.Property(u => u.OperationClaimId).HasColumnName("OperationClaimId").IsRequired();

            builder.HasQueryFilter(u => !u.DeletedDate.HasValue);

            builder.HasOne(uop => uop.User);
            builder.HasOne(uop => uop.OperationClaim);

        }
    }
}
