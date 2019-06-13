using NodaTime;
using System.Linq;
using TrainTable.Contract;

namespace TrainTable.Validators
{
    public class ThirtyFiveConescutiveHoursOfRestPerWeekChecker : IChecker
    {
        public void Check(ScheduleResponse response)
        {
            foreach (var driver in response.Drivers)
            {
                foreach (var assignment in driver.Assignments)
                {
                    var weekAssignments = driver.Assignments
                        .Where(a => a.Range.Day >= assignment.Range.Day)
                        .Where(a => a.Range.Day < assignment.Range.Day.PlusDays(7))
                        .Select(a => a.Range)
                        .ToList();
                    bool ok = false;
                    if (weekAssignments.Count > 0)
                    {
                        var restAtStart = (weekAssignments[0].ExactFrom - assignment.Range.ExactTo).ToDuration();
                        var restAtEnd = (assignment.Range.ExactFrom.PlusDays(7) - weekAssignments.Last().ExactTo).ToDuration();
                        if (restAtStart >= Duration.FromHours(35) || restAtEnd >= Duration.FromHours(35)) ok = true;
                    }
                    for(int i = 0; i < weekAssignments.Count-1; i++)
                    {
                        var rest = (weekAssignments[i + 1].ExactFrom - weekAssignments[i].ExactTo).ToDuration();
                        if (rest >= Duration.FromHours(35)) ok = true;
                    }
                    if (!ok)
                    {
                        throw new ValidationException();
                    }
                }
            }
        }
    }
}
