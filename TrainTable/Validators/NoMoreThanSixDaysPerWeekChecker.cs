using System.Linq;
using TrainTable.Contract;

namespace TrainTable.Validators
{
    public class NoMoreThanSixDaysPerWeekChecker : IChecker
    {
        public void Check(ScheduleResponse response)
        {
            foreach (var driver in response.Drivers)
            {
                foreach (var assignment in driver.Assignments)
                {
                    var total = driver.Assignments
                        .Where(a => a.Range.Day >= assignment.Range.Day)
                        .Where(a => a.Range.Day < assignment.Range.Day.PlusDays(7))
                        .Select(a => 1)
                        .Sum();
                    if (total > 6)
                        throw new ValidationException();
                }
            }
        }
    }
}
