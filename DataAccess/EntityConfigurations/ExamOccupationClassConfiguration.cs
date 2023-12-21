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
    public class ExamOccupationClassConfiguration : IEntityTypeConfiguration<ExamOccupationClass>
    {
        public void Configure(EntityTypeBuilder<ExamOccupationClass> builder)
        {
            builder.ToTable("ExamOccupationClasses").HasKey(r => r.Id);
            builder.Property(r => r.Id).HasColumnName("Id").IsRequired();
            builder.Property(r => r.ExamId).HasColumnName("ExamId").IsRequired();
            builder.Property(r => r.OccupationClassId).HasColumnName("OccupationClassId").IsRequired();

            builder.HasQueryFilter(q => !q.DeletedDate.HasValue);
        }
    }
}
