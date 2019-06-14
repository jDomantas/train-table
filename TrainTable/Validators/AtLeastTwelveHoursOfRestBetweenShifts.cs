using NodaTime;
using TrainTable.Contract;

namespace TrainTable.Validators
{
    public class AtLeastTwelveHoursOfRestBetweenShifts : IChecker
    {
        public void Check(ScheduleResponse response)
        {
            foreach(var driver in response.Drivers)
            {
                for (int i = 0; i < driver.Assignments.Count - 1; i++)
                {
                    if (driver.Assignments[i].Range.Day == driver.Assignments[i + 1].Range.Day)
                        continue;

                    var duration = driver.Assignments[i + 1].Range.ExactFrom - driver.Assignments[i].Range.ExactTo;
                    if (duration.ToDuration() < Duration.FromHours(12))
                    {
                        throw new ValidationException("You dun goofed");
                    }
                }
            }
        }
    }
}
