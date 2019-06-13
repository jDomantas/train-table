using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TrainTable.Contract;
using TrainTable.Repositories;
using TrainTable.Services;

namespace TrainTable.Controllers
{
    [Route("api/schedules")]
    public class SchedulesController : Controller
    {
        private readonly ISchedulingService _schedulingService;
        private readonly IRepository<Driver> _driverRepository;
        private readonly IRepository<Train> _trainRepository;

        public SchedulesController(
            ISchedulingService schedulingService,
            IRepository<Driver> driverRepository,
            IRepository<Train> trainRepository)
        {
            _schedulingService = schedulingService;
            _driverRepository = driverRepository;
            _trainRepository = trainRepository;
        }

        [HttpGet]
        public ScheduleResponse Get()
        {
            var trains = _trainRepository.GetAll().ToList();
            var drivers = _driverRepository.GetAll().ToList();
            return _schedulingService.Schedule(trains, drivers);
        }
    }
}
