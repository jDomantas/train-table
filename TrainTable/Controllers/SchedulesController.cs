using Microsoft.AspNetCore.Mvc;
using Serilog;
using TrainTable.Contract;

namespace TrainTable.Controllers
{
    [Route("api/schedules")]
    public class SchedulesController : Controller
    {
        [HttpGet]
        public TimetableResponse Get()
        {
            Log.Information("foo");
            return new TimetableResponse();
        }
    }
}
