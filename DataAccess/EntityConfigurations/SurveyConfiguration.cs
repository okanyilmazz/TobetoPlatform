using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations
{
    public class SurveyConfiguration : IEntityTypeConfiguration<Survey>
    {
        public void Configure(EntityTypeBuilder<Survey> builder)
        {
            builder.ToTable("Surveys").HasKey(s => s.Id);
            builder.Property(s => s.Id).HasColumnName("Id").IsRequired();
            builder.Property(s => s.Title).HasColumnName("Title").IsRequired();
            builder.Property(s => s.Content).HasColumnName("Content").IsRequired();
            builder.Property(s => s.ConnectionLink).HasColumnName("ConnectionLink").IsRequired();

            builder.HasMany(s => s.OccupationClasses)
                .WithMany(o => o.Surveys)
                .UsingEntity<OccupationClassSurvey>();

            builder.HasQueryFilter(s => !s.DeletedDate.HasValue);
        }
    }
}
