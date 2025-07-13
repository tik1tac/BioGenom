namespace Biogenom.Shared.Model;
/// <summary>
/// Раздел качества питания, создан, чтобы можно было расширять приложение другими функциями
/// </summary>
public class MealEntity
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public DateTime PassDate { get; set; } //дата прохождения

    public Guid IdUser { get; set; }
    public UserEntity User { get; set; }
    public List<MealElementsEntity> MealElement { get; set; }
    public List<NewDailyIntakeEntity> NewDailyIntake { get; set; }
}
