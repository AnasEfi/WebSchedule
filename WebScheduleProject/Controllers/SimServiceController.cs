using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.Diagnostics.Eventing.Reader;
using System.Security.Claims;
using WebScheduleProject.Data;
using WebScheduleProject.Models;

namespace WebScheduleProject.Controllers
{
    public class SimServiceController : Controller
    {
        private readonly WebScheduleProjectContext _context;

        public SimServiceController(WebScheduleProjectContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public async Task<IActionResult> Service()
        {
            var email = GetEmailFromCookie(HttpContext);
            ViewBag.Email = (await _context.Users.FirstOrDefaultAsync(p => p.Email == email))?.Username;
            if (email != null)
            {
                var userId = GetIdFromCookie(HttpContext);
                var listSimcards = await _context.SimCards
             .Where(s => s.UserId == userId)
             .Include(s => s.Services) // Загрузка связанных сервисов
             .ToListAsync();

                return View(listSimcards);
            }
           
            else return NoContent();
        }


        private string GetEmailFromCookie(HttpContext httpContext)
        {
            if (httpContext.User.Identity.IsAuthenticated)
            {
                var email = httpContext.User.FindFirst(ClaimTypes.Name)?.Value;
                return email;
            }
            return null;
        }
        private int GetIdFromCookie(HttpContext httpContext)
        {
            if (httpContext.User.Identity.IsAuthenticated)
            {
                var parced = int.TryParse(httpContext.User.FindFirst("Id")?.Value, out int id);
                return id;
            }
            else return -1;
        }

    }
}
