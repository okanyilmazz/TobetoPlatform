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
    public class CalendarSessionConfiguration : IEntityTypeConfiguration<CalendarSession>
    {
        public void Configure(EntityTypeBuilder<CalendarSession> builder)
        {
            builder.ToTable("CalendarSessions").HasKey(b => b.Id);

            builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
            builder.Property(c => c.SessionId).HasColumnName("SessionId").IsRequired();
            builder.Property(c => c.UserOperationClaimId).HasColumnName("UserOperationClaimId").IsRequired();

            builder.HasIndex(indexExpression: c => c.Id, name: "UK_Id").IsUnique();

            builder.HasOne(c => c.UserOperationClaim);
            builder.HasOne(c => c.Session);

            builder.HasQueryFilter(c => !c.DeletedDate.HasValue);


        }
    }
}
