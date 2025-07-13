using Biogenom.Shared.Model;
using Biogenom.Shared.Model.Configuration;

using Microsoft.EntityFrameworkCore;

namespace Biogenom.Shared;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions options)
    : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new ConfigurataionElements());
        modelBuilder.ApplyConfiguration(new ConfigurataionMeal());
        modelBuilder.ApplyConfiguration(new ConfigurataionUser());
        modelBuilder.ApplyConfiguration(new ConfigurationNeDailyIntake());
        modelBuilder.ApplyConfiguration(new ConfigurationProduct());
        modelBuilder.ApplyConfiguration(new ConfigurationRecommendetaionDietary());
        modelBuilder.ApplyConfiguration(new ConfigurationElementMeal());
    }

    public DbSet<ElementsEntity> Elements { get; set; }
    public DbSet<MealEntity> Meal { get; set; }
    public DbSet<UserEntity> User { get; set; }
    public DbSet<NewDailyIntakeEntity> NewDailyIntake { get; set; }
    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<RecommendetaionDietaryEntity> RecDietary { get; set; }
    public DbSet<MealElementsEntity> MealElements { get; set; }
}
