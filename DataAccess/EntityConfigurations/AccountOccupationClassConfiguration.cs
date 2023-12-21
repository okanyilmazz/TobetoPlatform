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
    public class AccountOccupationClassConfiguration : IEntityTypeConfiguration<AccountOccupationClass>
    {
        public void Configure(EntityTypeBuilder<AccountOccupationClass> builder)
        {
            builder.ToTable("AccountOccupationClasses").HasKey(a => a.Id);
            builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
        }
    }
}
