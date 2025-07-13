using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biogenom.Shared.Model.Configuration;

internal class ConfigurataionMeal : IEntityTypeConfiguration<MealEntity>
{
    public void Configure(EntityTypeBuilder<MealEntity> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

    }
}
