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
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {

        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("Cities").HasKey(c => c.Id);
            builder.Property(c => c.CountryId).HasColumnName("CountryId").IsRequired();
            builder.Property(c => c.Name).HasColumnName("Name").IsRequired();
            builder.HasIndex(indexExpression: c => c.Name, name: "UK_Name").IsUnique();
            builder.HasIndex(indexExpression: c => c.CountryId, name: "UK_CountryId").IsUnique();
            builder.HasQueryFilter(l => !l.DeletedDate.HasValue);
        }
    }
}


