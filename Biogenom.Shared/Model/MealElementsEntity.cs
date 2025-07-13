namespace Biogenom.Shared.Model;

public class MealElementsEntity
{
    public Guid IdElements { get; set; }
    public ElementsEntity Elements { get; set; }
    public Guid IdMeal { get; set; }
    public MealEntity Meal { get; set; }
    public double CurrentValue { get; set; } //текущее значение
}
