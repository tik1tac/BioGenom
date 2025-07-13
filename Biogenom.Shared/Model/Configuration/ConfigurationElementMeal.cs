using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biogenom.Shared.Model.Configuration;

internal class ConfigurationElementMeal : IEntityTypeConfiguration<MealElementsEntity>
{
    public void Configure(EntityTypeBuilder<MealElementsEntity> builder)
    {
        builder.HasKey(um => new { um.IdMeal, um.IdElements });

        builder.HasOne(p => p.Meal)
     .WithMany(p => p.MealElement)
     .HasForeignKey(p => p.IdMeal);

        builder.HasOne(p => p.Elements)
.WithMany(p => p.MealElements)
.HasForeignKey(p => p.IdElements);
    }
}
