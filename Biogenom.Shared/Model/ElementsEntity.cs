namespace Biogenom.Shared.Model;
/// <summary>
/// Витамины и вещества которых хватает/не хватает
/// </summary>
public class ElementsEntity 
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public double? CurrentValue { get; set; }
    public double? FromNorm {  get; set; }
    public double? ToNorm { get; set; }
    public bool? InNorm { get; set; }
    public Guid IdMeal { get; set; }
    public MealEntity Meal { get; set; }

    public NewDailyIntakeEntity NewDailyIntake { get; set; }
}
