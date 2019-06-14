using Microsoft.AspNetCore.Mvc;

namespace TrainTable.Controllers
{
    [Route("/")]
    public class UiController : Controller
    {
        [HttpGet]
        public ActionResult Get()
        {
            return File("index.html", "text/html");
        }
    }
}
