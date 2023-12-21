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
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Addresses").HasKey("Id");
            builder.Property(a => a.CityId).HasColumnName("CityId").IsRequired();
            builder.Property(a => a.CountryId).HasColumnName("CountryId").IsRequired();
            builder.Property(a => a.DistrictId).HasColumnName("DistrictId").IsRequired();
            builder.Property(a => a.AddressDetail).HasColumnName("AddressDetail").IsRequired();
            builder.HasQueryFilter(d => !d.DeletedDate.HasValue);
        }
    }
}
