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
    public class SessionConfiguration : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.ToTable("Sessions").HasKey(s => s.Id);
            builder.Property(s => s.Id).HasColumnName("Id").IsRequired();
            builder.Property(s => s.OccupationClassId).HasColumnName("OccupationClassId");
            builder.Property(s => s.StartDate).HasColumnName("StartDate");
            builder.Property(s => s.EndDate).HasColumnName("EndDate");
            builder.Property(s => s.RecordPath).HasColumnName("RecordPath");

            builder.HasMany(s => s.Accounts)
                .WithMany(s => s.Sessions)
                .UsingEntity<AccountSession>();

            builder.HasOne(s => s.OccupationClass)
                .WithMany(s => s.Sessions)
                .HasForeignKey(s => s.OccupationClassId);

            builder.HasQueryFilter(s => !s.DeletedDate.HasValue);
        }
    }
}
