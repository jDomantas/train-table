using TrainTable.Contract;

namespace TrainTable.Validators
{
    public class NoAssignmentsCollideChecker : IChecker
    {
        public void Check(ScheduleResponse response)
        {
            foreach(var driver in response.Drivers)
            {
                for(int i = 0; i < driver.Assignments.Count-1; i++)
                {
                    if(driver.Assignments[i+1].Range.ExactFrom < driver.Assignments[i].Range.ExactTo)
                    {
                        throw new ValidationException();
                    }
                }
            }
        }
    }
}
