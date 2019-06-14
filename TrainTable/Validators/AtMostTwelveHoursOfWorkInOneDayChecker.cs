using NodaTime;
using System.Linq;
using TrainTable.Contract;

namespace TrainTable.Validators
{
    public class AtMostTwelveHoursOfWorkInOneDayChecker : IChecker
    {
        public void Check(ScheduleResponse response)
        {
            foreach (var driver in response.Drivers)
            {
                foreach (var assignment in driver.Assignments)
                {
                    var totalWork = driver.Assignments
                        .Where(a => a.Range.Day == assignment.Range.Day)
                        .Aggregate(Duration.Zero, (a, b) => a + b.Range.Duration);

                    if (totalWork > Duration.FromHours(12))
                        throw new ValidationException();
                }
            }
        }
    }
}
