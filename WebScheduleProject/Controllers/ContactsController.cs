using Microsoft.AspNetCore.Mvc;

namespace WebWTF.Controllers
{
    public class ContactsController : Controller
    {
        public IActionResult Index()
        {
            
            return View();
        }
    }
}
