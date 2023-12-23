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
    public class AccountOccupationClassConfiguration : IEntityTypeConfiguration<AccountOccupationClass>
    {
        public void Configure(EntityTypeBuilder<AccountOccupationClass> builder)
        {
            builder.ToTable("AccountOccupationClasses").HasKey(a => a.Id);
            builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
            builder.HasIndex(indexExpression: a => a.Id, name: "UK_Id").IsUnique();
            builder.Property(a => a.OccupationClassId).HasColumnName("OccupationClassId").IsRequired();
            builder.HasIndex(indexExpression: a => a.OccupationClassId, name: "UK_OccupationClassId").IsUnique();
            builder.Property(a => a.AccountId).HasColumnName("AccountId").IsRequired();
            builder.HasIndex(indexExpression: a => a.AccountId, name: "UK_AccountId").IsUnique();

            builder.HasQueryFilter(a => !a.DeletedDate.HasValue);

            builder.HasOne(a=>a.OccupationClass);
            builder.HasOne(a=>a.Account);
        }
    }
}
