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
    public class AccountLanguageConfiguration : IEntityTypeConfiguration<AccountLanguage>
    {
        public void Configure(EntityTypeBuilder<AccountLanguage> builder)
        {
            builder.ToTable("AccountLanguages").HasKey(l => l.Id);
            builder.Property(l => l.Id).HasColumnName("Id").IsRequired();
            builder.HasQueryFilter(l => !l.DeletedDate.HasValue);
        }
    }
}
