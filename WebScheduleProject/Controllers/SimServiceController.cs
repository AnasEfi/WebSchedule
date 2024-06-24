using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebScheduleProject.Controllers 
{
    public class SimServiceController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public IActionResult Service()
        {
            return View();
        }
    }
}
