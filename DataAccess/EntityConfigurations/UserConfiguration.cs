using Entities.Concretes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace DataAccess.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users").HasKey(u => u.Id);

            builder.Property(u => u.Id).HasColumnName("Id").IsRequired();
            builder.Property(u => u.FirstName).HasColumnName("FirstName").IsRequired();
            builder.Property(u => u.LastName).HasColumnName("LastName").IsRequired();
            builder.Property(u => u.Email).HasColumnName("Email").IsRequired();
            builder.Property(u => u.PasswordSalt).HasColumnName("PasswordSalt");
            builder.Property(u => u.PasswordHash).HasColumnName("PasswordHash");
            builder.Property(u => u.Password).HasColumnName("Password").IsRequired();
            builder.Property(u => u.Status).HasColumnName("Status").IsRequired();

            builder.HasIndex(indexExpression: u => u.Id, name: "UK_Id").IsUnique();
            builder.HasIndex(indexExpression: u => u.Email, name: "UK_Email").IsUnique();



            builder.HasQueryFilter(u => !u.DeletedDate.HasValue);
        }
    }
}
