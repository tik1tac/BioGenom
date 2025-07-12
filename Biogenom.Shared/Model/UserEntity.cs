namespace Biogenom.Shared.Model;

public class UserEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = "User1";
    public MealEntity Meal { get; set; }
}
