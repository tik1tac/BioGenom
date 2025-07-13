namespace Biogenom.Shared.Model;
/// <summary>
/// Новое суточное потребление с учетом препаратов и питания (2 раздел который идет после достатка/недостатка питания)
/// </summary>
public class NewDailyIntakeEntity
{
    public Guid Id { get; set; }
    public double? FromProduct { get; set; } //Сколько должен брать витаминов и веществ от препаратов
    public double? FromMeal { get; set; } // Сколько должен брать витаминов и веществ из еды
    public string? Description { get; set; }
    public RecommendetaionDietaryEntity RecommendetaionDietary { get; set; } //Продукты которые необходимо употреблять
    public Guid? IdMeal { get; set; }
    public MealEntity Meal { get; set; }
    public List<ProductEntity> Product { get; set; }
    public ElementsEntity Elements { get; set; }

}
