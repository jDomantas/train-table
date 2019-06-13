using NodaTime;
using System.Linq;
using TrainTable.Contract;

namespace TrainTable.Validators
{
    public class NoMoreThanFortyEightHoursInSevenDaysChecker : IChecker
    {
        public void Check(ScheduleResponse response)
        {
            foreach(var driver in response.Drivers)
            {
                foreach (var assignment in driver.Assignments)
                {
                    var total = driver.Assignments
                        .Where(a => a.Range.Day >= assignment.Range.Day)
                        .Where(a => a.Range.Day < assignment.Range.Day.PlusDays(7))
                        .Select(a => a.Range.Duration)
                        .Aggregate(Duration.Zero, (a, b) => a + b);
                    if (total > Duration.FromHours(48))
                        throw new ValidationException();
                }
            }
        }
    }
}
