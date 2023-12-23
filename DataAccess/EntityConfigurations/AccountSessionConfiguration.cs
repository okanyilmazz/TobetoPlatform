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
    public class AccountSessionConfiguration : IEntityTypeConfiguration<AccountSession>
    {
        public void Configure(EntityTypeBuilder<AccountSession> builder)
        {
            builder.ToTable("AccountSessions").HasKey(a => a.Id);
            builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
            builder.HasIndex(indexExpression: a => a.Id, name: "UK_Id").IsUnique();
            builder.Property(a => a.SessionId).HasColumnName("SessionId").IsRequired();
            builder.HasIndex(indexExpression: a => a.SessionId, name: "UK_SessionId").IsUnique();
            builder.Property(a => a.AccountId).HasColumnName("AccountId").IsRequired();
            builder.HasIndex(indexExpression: a => a.AccountId, name: "UK_AccountId").IsUnique();
            builder.Property(a => a.Status).HasColumnName("Status").IsRequired();

            builder.HasQueryFilter(a => !a.DeletedDate.HasValue);

            builder.HasOne(a=>a.Session);
            builder.HasOne(a=>a.Account);

        }
    }
}
