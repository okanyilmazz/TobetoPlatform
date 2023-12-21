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
    public class AccountAnswerConfiguration : IEntityTypeConfiguration<AccountAnswer>
    {
        public void Configure(EntityTypeBuilder<AccountAnswer> builder)
        {
            builder.ToTable("AccountAnswers").HasKey(b => b.Id);
            builder.Property(b => b.GivenAnswer).HasColumnName("GivenAnswer").IsRequired();
            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }
    }
}
