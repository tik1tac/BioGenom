using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biogenom.Shared.Model.Configuration;

internal class ConfigurationNeDailyIntake : IEntityTypeConfiguration<NewDailyIntakeEntity>
{
    public void Configure(EntityTypeBuilder<NewDailyIntakeEntity> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.HasOne(p => p.Meal)
            .WithMany(p => p.NewDailyIntake)
            .HasForeignKey(p => p.IdMeal);
        builder.HasOne(p => p.Elements)
            .WithOne(p => p.NewDailyIntake)
            .HasForeignKey<ElementsEntity>(p => p.IdNewDailyIntake);
        builder.HasOne(p => p.RecommendetaionDietary)
            .WithOne(p=>p.NewDailyIntake)
            .HasForeignKey<RecommendetaionDietaryEntity>(p=>p.IdNewDailyIntake);
    }
}
