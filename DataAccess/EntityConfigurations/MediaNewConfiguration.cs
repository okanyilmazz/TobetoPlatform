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
    public class MediaNewConfiguration : IEntityTypeConfiguration<MediaNew>
    {
        public void Configure(EntityTypeBuilder<MediaNew> builder)
        {
            builder.ToTable("MediaNews").HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
            builder.Property(c => c.Title).HasColumnName("Title").IsRequired();
            builder.HasIndex(indexExpression: c => c.Title, name: "UK_Title").IsUnique();
            builder.HasQueryFilter(c => !c.DeletedDate.HasValue);
        }
    }
}
                            