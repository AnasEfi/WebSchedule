using Microsoft.AspNetCore.Mvc;

namespace WebWTF.Controllers
{
    public class SimServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
