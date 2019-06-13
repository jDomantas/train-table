using TrainTable.Contract;

namespace TrainTable.Validators
{
    public class NoMoreThanTwoNightShiftsInARowChecker : IChecker
    {
        public void Check(ScheduleResponse response)
        {
            foreach (var driver in response.Drivers)
            {
                for (int i = 0; i < driver.Assignments.Count - 2; i++)
                {
                    var range1 = driver.Assignments[i+0].Range;
                    var range2 = driver.Assignments[i+1].Range;
                    var range3 = driver.Assignments[i+2].Range;
                    if (range1.IsNightShift && range2.IsNightShift && range3.IsNightShift)
                    {
                        throw new ValidationException("You dun goofed");
                    }
                }
            }
        }
    }
}
