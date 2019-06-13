using Microsoft.AspNetCore.Mvc;
using NodaTime;
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

        [Route("test")]
        [HttpGet]
        public DateRange GetDR()
        {
            return new DateRange()
            {
                Day = new LocalDate(2019, 06, 14),
                From = new LocalTime(4, 0),
                To = new LocalTime(22, 0)
            };
        }
    }
}
