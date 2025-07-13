using Biogenom.Shared.Model;

namespace Biogenom.API;

public class GetNewDailyIntake
{
    public List<NewDailyIntakeEntity> NewDailyIntake { get; set; }
    public List<double> CurrentValue { get; set; }
    public GetNewDailyIntake(List<NewDailyIntakeEntity> newDailyIntakeEntity, List<double> curVal) => (NewDailyIntake, CurrentValue) = (newDailyIntakeEntity, CurrentValue);
}
