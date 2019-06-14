using Microsoft.AspNetCore.Mvc;
using Serilog;
using TrainTable.Contract;
using TrainTable.Evaluators;
using TrainTable.Services;

namespace TrainTable.Controllers
{
    [Route("api/schedules/random")]
    public class RandomSchedulesController : Controller
    {
        private readonly RandomSchedulingService _schedulingService;
        private readonly IEvaluator _evaluator;

        public RandomSchedulesController(
            RandomSchedulingService schedulingService,
            IEvaluator evaluator)
        {
            _schedulingService = schedulingService;
            _evaluator = evaluator;
        }

        [HttpGet]
        [Route("")]
        public ScheduleResponse Get()
        {
            Log.Information("Generating schedule with random strategy");
            var response = _schedulingService.GetSchedule();
            Log.Information("Generated a schedule with score {0}", _evaluator.Evaluate(response));
            return response;
        }

        [HttpPost]
        [Route("new")]
        public ScheduleResponse RegenerateSchedule()
        {
            Log.Information("Regenerating schedule with random strategy");
            var response = _schedulingService.GenerateAndSaveSchedule();
            Log.Information("Generated a schedule with score {0}", _evaluator.Evaluate(response));
            return response;
        }

        [HttpDelete]
        [Route("{assignmentId}")]
        public ScheduleResponse DeleteAssignment(string assignmentId)
        {
            Log.Information("Deleting assignment from random schedule with ID {0}", assignmentId);
            _schedulingService.DeleteAssignment(assignmentId);
            var response = _schedulingService.GetSchedule();
            Log.Information("New schedule score {0}", _evaluator.Evaluate(response));
            return response;
        }

        [HttpPost]
        [Route("")]
        public ScheduleResponse AddAssignment([FromBody] AddAssignmentRequest request)
        {
            Log.Information("Adding assignment to random schedule");
            _schedulingService.AddAssignment(request);
            var response = _schedulingService.GetSchedule();
            Log.Information("New schedule score {0}", _evaluator.Evaluate(response));
            return response;
        }
    }
}
