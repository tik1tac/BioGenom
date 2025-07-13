namespace Biogenom.Shared.Model;
/// <summary>
/// Витамины и вещества которых хватает/не хватает
/// </summary>
public class ElementsEntity 
{
    public Guid Id { get; set; }
    public string Name { get; set; } //Название
    public string? Description { get; set; }
    public double? FromNorm {  get; set; } //Норма от такого-то значения
    public double? ToNorm { get; set; } //Норма до такого-то значения
    public bool? InNorm { get; set; } //В норме ли находится
    public List<MealElementsEntity> MealElements { get; set; }

    public Guid IdNewDailyIntake { get; set; }
    public NewDailyIntakeEntity NewDailyIntake { get; set; }
}
