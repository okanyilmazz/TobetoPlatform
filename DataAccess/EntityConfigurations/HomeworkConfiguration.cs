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
    public class HomeworkConfiguration : IEntityTypeConfiguration<Homework>
    {
        public void Configure(EntityTypeBuilder<Homework> builder)
        {
            builder.ToTable("Homeworks").HasKey(h => h.Id);
            builder.Property(h => h.Id).HasColumnName("Id").IsRequired();
            builder.Property(h => h.Name).HasColumnName("Name").IsRequired();
            builder.Property(h => h.Description).HasColumnName("Description").IsRequired();
            builder.Property(h => h.FilePath).HasColumnName("FilePath").IsRequired();
            builder.Property(h => h.Deadline).HasColumnName("DeadLine").IsRequired();
            builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
        }
    }
}
