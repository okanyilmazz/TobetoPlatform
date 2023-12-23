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
            builder.ToTable("AccountLanguages").HasKey(a => a.Id);
            builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
            builder.HasIndex(indexExpression: a => a.Id, name: "UK_Id").IsUnique();
            builder.Property(a => a.AccountId).HasColumnName("AccountId").IsRequired();
            builder.HasIndex(indexExpression: a => a.AccountId, name: "UK_AccountId").IsUnique();
            builder.Property(a => a.LanguageId).HasColumnName("LanguageId").IsRequired();
            builder.HasIndex(indexExpression: a => a.LanguageId, name: "UK_LanguageId").IsUnique();
            builder.Property(a => a.LanguageLevelId).HasColumnName("LanguageLevelId").IsRequired();
            builder.HasIndex(indexExpression: a => a.LanguageLevelId, name: "UK_LanguageLevelId").IsUnique();

            builder.HasQueryFilter(a => !a.DeletedDate.HasValue);

            builder.HasOne(a=>a.Account);
            builder.HasOne(a=>a.Language);
            builder.HasOne(a=>a.LanguageLevel);

        }
    }
}
