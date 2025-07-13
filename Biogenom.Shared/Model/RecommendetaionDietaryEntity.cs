namespace Biogenom.Shared.Model;
/// <summary>
/// Рекомендованное питание и продукты для употребления
/// </summary>
public class RecommendetaionDietaryEntity
{
    public Guid Id { get; set; }
    public string NameDietary {  get; set; }
    public string Description {  get; set; }
    public Guid IdNewDailyIntake { get; set; }
    public NewDailyIntakeEntity NewDailyIntake { get; set; }
}
