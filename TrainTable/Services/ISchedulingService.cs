using System.Collections.Generic;
using TrainTable.Contract;

namespace TrainTable.Services
{
    public interface ISchedulingService
    {
        ScheduleResponse Schedule(List<Train> trains, List<Driver> drivers);
    }
}
