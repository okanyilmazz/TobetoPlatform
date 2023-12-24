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
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Projects").HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("Id").IsRequired();
            builder.Property(p => p.Name).HasColumnName("Name").IsRequired();
            builder.HasIndex(indexExpression: p => p.Name, name: "UK_Name").IsUnique();
            builder.HasQueryFilter(p => !p.DeletedDate.HasValue);

            builder.HasMany(a => a.Announcements)
                .WithMany(a => a.Projects)
                .UsingEntity<AnnouncementProject>();
        }
    }
}
