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
        private readonly RandomSchedulingService _randomSchedulingService;
        private readonly PrioritizingSchedulingService _prioritizingSchedulingService;
        private readonly IRepository<Driver> _driverRepository;
        private readonly IRepository<Train> _trainRepository;

        public SchedulesController(
            RandomSchedulingService randomSchedulingService,
            PrioritizingSchedulingService prioritizingSchedulingService,
            IRepository<Driver> driverRepository,
            IRepository<Train> trainRepository)
        {
            _randomSchedulingService = randomSchedulingService;
            _prioritizingSchedulingService = prioritizingSchedulingService;
            _driverRepository = driverRepository;
            _trainRepository = trainRepository;
        }

        [HttpGet]
        [Route("random")]
        public ScheduleResponse GetRandom()
        {
            var trains = _trainRepository.GetAll().ToList();
            var drivers = _driverRepository.GetAll().ToList();
            return _randomSchedulingService.Schedule(trains, drivers);
        }

        [HttpGet]
        [Route("prioritized")]
        public ScheduleResponse GetPrioritized()
        {
            var trains = _trainRepository.GetAll().ToList();
            var drivers = _driverRepository.GetAll().ToList();
            return _prioritizingSchedulingService.Schedule(trains, drivers);
        }
    }
}
