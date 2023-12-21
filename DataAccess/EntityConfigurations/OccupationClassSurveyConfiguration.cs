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
    public class OccupationClassSurveyConfiguration : IEntityTypeConfiguration<OccupationClassSurvey>
    {
        public void Configure(EntityTypeBuilder<OccupationClassSurvey> builder)
        {
            builder.ToTable("OccupationClassSurveys").HasKey(o => o.Id);
            builder.Property(o => o.SurveyId).HasColumnName("SurveyId").IsRequired();
            builder.Property(o => o.OccupationClassId).HasColumnName("OccupationClassId").IsRequired();
            builder.HasIndex(indexExpression: o => o.SurveyId, name: "UK_SurveyId").IsUnique();
            builder.HasIndex(indexExpression: o => o.OccupationClassId, name: "UK_OccupationClassId").IsUnique();
            builder.HasQueryFilter(o => !o.DeletedDate.HasValue);
        }
    }
}
