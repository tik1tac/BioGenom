namespace Biogenom.Shared.Model;
/// <summary>
/// Раздел качества питания, создан, чтобы можно было расширять приложение другими функциями
/// </summary>
public class MealEntity
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public DateTime PassDate { get; set; }

    public UserEntity User { get; set; }
    public List<ElementsEntity> Elements { get; set; }
    public List<NewDailyIntakeEntity> NewDailyIntake { get; set; }
}
