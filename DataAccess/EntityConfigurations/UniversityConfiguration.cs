using Entities.Concretes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityConfigurations
{
    public class UniversityConfiguration : IEntityTypeConfiguration<University>
    {
        public void Configure(EntityTypeBuilder<University> builder)
        {
            builder.ToTable("Universities").HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
            builder.Property(c => c.Name).HasColumnName("Name").IsRequired();
            builder.HasIndex(indexExpression: c => c.Name, name: "UK_Name").IsUnique();
            builder.HasQueryFilter(c => !c.DeletedDate.HasValue);

            builder.HasMany(e => e.Accounts)
                .WithMany(e => e.Universities)
                .UsingEntity<AccountUniversity>();
        }
    }
}
