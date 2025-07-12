namespace Biogenom.Shared.Model;
/// <summary>
/// Препараты которые помогут для улучшения питания
/// </summary>
public class ProductEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public Guid IdNewDailyIntake { get; set; }
    public NewDailyIntakeEntity NewDailyIntake { get; set; }
}
