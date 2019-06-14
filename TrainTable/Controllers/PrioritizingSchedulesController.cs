﻿using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Collections.Generic;
using TrainTable.Contract;
using TrainTable.Evaluators;
using TrainTable.Services;
using TrainTable.Validators;

namespace TrainTable.Controllers
{
    [Route("api/schedules/prioritized")]
    public class PrioritizingSchedulesController : Controller
    {
        private readonly PrioritizingSchedulingService _schedulingService;
        private readonly IEvaluator _evaluator;

        public PrioritizingSchedulesController(
            PrioritizingSchedulingService schedulingService,
            IEvaluator evaluator)
        {
            _schedulingService = schedulingService;
            _evaluator = evaluator;
        }

        [HttpGet]
        [Route("")]
        public ScheduleResponse Get()
        {
            Log.Information("Generating schedule with prioritizing strategy");
            var response = _schedulingService.GetSchedule();
            Log.Information("Generated a schedule with score {0}", _evaluator.Evaluate(response));
            return response;
        }

        [HttpPost]
        [Route("new")]
        public ScheduleResponse RegenerateSchedule()
        {
            Log.Information("Regenerating schedule with prioritizing strategy");
            var response = _schedulingService.GenerateAndSaveSchedule();
            Log.Information("Generated a schedule with score {0}", _evaluator.Evaluate(response));
            return response;
        }

        [HttpDelete]
        [Route("{assignmentId}")]
        public ScheduleResponse DeleteAssignment(string assignmentId)
        {
            Log.Information("Deleting assignment from prioritizing schedule with ID {0}", assignmentId);
            _schedulingService.DeleteAssignment(assignmentId);
            var response = _schedulingService.GetSchedule();
            Log.Information("New schedule score {0}", _evaluator.Evaluate(response));
            return response;
        }

        [HttpPost]
        [Route("move")]
        public IActionResult MoveAssignment([FromBody] MoveAssignmentRequest request)
        {
            Log.Information("Adding assignment to prioritizing schedule");
            try
            {
                _schedulingService.MoveAssignment(request.AssignmentId, request.DriverId);
                var response = _schedulingService.GetSchedule();
                Log.Information("New schedule score {0}", _evaluator.Evaluate(response));
                return Ok(response);
            }
            catch(ValidationException)
            {
                return StatusCode(409);
            }
        }

        [HttpPost]
        [Route("freeDrivers")]
        public List<Driver> GetFreeDrivers([FromBody] DateRange range)
        {
            return _schedulingService.GetFreeDrivers(range);
        }
    }
}
