using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biogenom.Shared.Model.Configuration;

internal class ConfigurationRecommendetaionDietary : IEntityTypeConfiguration<RecommendetaionDietaryEntity>
{
    public void Configure(EntityTypeBuilder<RecommendetaionDietaryEntity> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.HasOne(p => p.NewDailyIntake)
            .WithOne(p => p.RecommendetaionDietary)
            .HasForeignKey<NewDailyIntakeEntity>(p => p.Id);
    }
}
