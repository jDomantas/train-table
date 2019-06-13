using Microsoft.AspNetCore.Mvc;
using TrainTable.Contract;
using TrainTable.Repositories;
using TrainTable.Services;

namespace TrainTable.Controllers
{
    [Route("api/schedules")]
    public class SchedulesController : Controller
    {
        private readonly SchedulingService _schedulingService = new SchedulingService();
        private readonly DriverRepository _driverRepository = new DriverRepository();
        private readonly TrainRepository _trainRepository = new TrainRepository();

        [HttpGet]
        public ScheduleResponse Get()
        {
            var trains = _trainRepository.GetTrains();
            var drivers = _driverRepository.GetDrivers();
            return _schedulingService.GenerateSchedule(trains, drivers);
        }
    }
}
