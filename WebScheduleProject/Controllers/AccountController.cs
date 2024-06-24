using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System;
using System.Security.Claims;
using WebScheduleProject.Data;
using WebScheduleProject.Models;

namespace WebScheduleProject.Controllers
{

    [Authorize]
    public class AccountController : Controller
    {
        private readonly WebScheduleProjectContext _context;

        public AccountController(WebScheduleProjectContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([Bind("Email,Password")] LoginUser model, string ReturnUrl)
        {
            Console.WriteLine("пришли в логин");
            Console.WriteLine(model.Email + ": email");
            Console.WriteLine(model.Password + ": pwd");

            if (_context.User == null)
            {
                Console.WriteLine("romble found");
                return Problem("Entity set Users is empty");
            }

            var users = from u in _context.User
                        select u;

            User? user = users.FirstOrDefault(p => p.Email == model.Email && p.Password == model.Password);
            if (user is null) return Unauthorized();
            else
            {
                List<Claim> claims = new List<Claim> { new Claim(ClaimTypes.Name, user.Email) };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));
                return Redirect(ReturnUrl == null ? "/" : ReturnUrl);
            }
        }

        public IActionResult SignIn()
        {
            return View();
        }

        public IActionResult Logout()
        {
            return View();
        }
    }
}
