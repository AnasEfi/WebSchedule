using Microsoft.AspNetCore.Mvc;

namespace WebScheduleProject.Controllers 
{
    public class SimServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
