using System;
using System.Collections.Generic;

namespace TrainTable.Contract
{
    [Serializable]
    public class ScheduleResponse
    {
        public List<Driver> Drivers;
        public List<Assignment> Unassigned;
    }
}
