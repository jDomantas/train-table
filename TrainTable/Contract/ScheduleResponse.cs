using System.Collections.Generic;

namespace TrainTable.Contract
{
    public class ScheduleResponse
    {
        public List<Driver> Drivers;
        public List<Assignment> Unassigned;
    }
}
