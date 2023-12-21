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
    public class AccountSkillConfiguration : IEntityTypeConfiguration<AccountSkill>
    {
        public void Configure(EntityTypeBuilder<AccountSkill> builder)
        {
            builder.ToTable("AccountSkills").HasKey(a => a.Id);
            builder.Property(a => a.AccountId).HasColumnName("AccountId").IsRequired();
            builder.Property(a => a.SkillId).HasColumnName("SkillId").IsRequired();
            builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
        }
    }
}
