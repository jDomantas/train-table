using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Linq;
using TrainTable.Contract;
using TrainTable.Evaluators;
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
        private readonly IEvaluator _evaluator;

        public SchedulesController(
            RandomSchedulingService randomSchedulingService,
            PrioritizingSchedulingService prioritizingSchedulingService,
            IRepository<Driver> driverRepository,
            IRepository<Train> trainRepository,
            IEvaluator evaluator)
        {
            _randomSchedulingService = randomSchedulingService;
            _prioritizingSchedulingService = prioritizingSchedulingService;
            _driverRepository = driverRepository;
            _trainRepository = trainRepository;
            _evaluator = evaluator;
        }

        [HttpGet]
        [Route("random")]
        public ScheduleResponse GetRandom()
        {
            Log.Information("Generating schedule with random strategy");
            var trains = _trainRepository.GetAll().ToList();
            var drivers = _driverRepository.GetAll().ToList();
            var response = _randomSchedulingService.Schedule(trains, drivers);
            Log.Information("Generated a schedule with score {0}", _evaluator.Evaluate(response));
            return response;
        }

        [HttpGet]
        [Route("prioritized")]
        public ScheduleResponse GetPrioritized()
        {
            Log.Information("Generating schedule with prioritized strategy");
            var trains = _trainRepository.GetAll().ToList();
            var drivers = _driverRepository.GetAll().ToList();
            var response = _prioritizingSchedulingService.Schedule(trains, drivers);
            Log.Information("Generated a schedule with score {0}", _evaluator.Evaluate(response));
            return response;
        }
    }
}
