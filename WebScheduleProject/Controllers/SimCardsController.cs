using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using WebScheduleProject.Data;
using WebScheduleProject.Models;

namespace WebScheduleProject.Controllers
{
    public class SimCardsController : Controller
    {
        private readonly WebScheduleProjectContext _context;

        public SimCardsController(WebScheduleProjectContext context)
        {
            _context = context;
        }


        // GET: SimCards
        public async Task<IActionResult> Index()
        {
            return View(await _context.SimCards.ToListAsync());
        }

        // GET: SimCards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var simCard = await _context.SimCards
                .FirstOrDefaultAsync(m => m.Id == id);
            if (simCard == null)
            {
                return NotFound();
            }

            return View(simCard);
        }

        // GET: SimCards/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SimCards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SimNumber,Provider")] SimCard simCard)
        {
            if (ModelState.IsValid)
            {
                var currenUserId = GetUserIdFromCookie(HttpContext);
                simCard.UserId = currenUserId;
                _context.SimCards.Add(simCard);
                await _context.SaveChangesAsync();
                return RedirectToAction("Service", "SimService");
            }
            return View(simCard);
        }


        private int GetUserIdFromCookie(HttpContext httpContext)
        {
            if (httpContext.User.Identity.IsAuthenticated)
            {
                bool success = int.TryParse(httpContext.User.FindFirst("Id")?.Value, out int Id);
                return Id;
            }
            return -1;
        }

        // GET: SimCards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var simCard = await _context.SimCards.FindAsync(id);
            if (simCard == null)
            {
                return NotFound();
            }
            return View(simCard);
        }

        // POST: SimCards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SimNumber,Services,Provider")] SimCard simCard)
        {
            if (id != simCard.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(simCard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SimCardExists(simCard.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Service", "SimService");
            }
            return View(simCard);
        }


        public IActionResult AddService(int id)
        {
            var item = _context.SimCards.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddService(int id, [Bind("Id,SimNumber,Services,Provider")] SimCard simCard)

        {
            var item = _context.SimCards.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            try
            {
                string? serviceName = Request.Form["serviceNameInput"];
                int serviceId = await ServiceController.GetIdOfServiceByNameStatic(_context, serviceName);
                if (serviceId == -1)
                {
                    var newService = new Service { ServiceName = serviceName };
                    _context.Services.Add(newService);
                    await _context.SaveChangesAsync();
                    // Попытка найти сервис по имени
                    serviceId = await ServiceController.GetIdOfServiceByNameStatic(_context, serviceName);
                }
                item.Services.Add(await _context.Services.FirstOrDefaultAsync(s => s.Id == serviceId));
                try
                {
                    _context.SimCards.Update(item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    Console.WriteLine("error in DBfunc Update SimCard");
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SimCardExists(simCard.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction("Service", "SimService");

        }



        // GET: SimCards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var simCard = await _context.SimCards
                .FirstOrDefaultAsync(m => m.Id == id);
            if (simCard == null)
            {
                return NotFound();
            }

            return View(simCard);
        }

        // POST: SimCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var simCard = await _context.SimCards.FindAsync(id);
            _context.SimCards.Remove(simCard!);
            await _context.SaveChangesAsync();
            return RedirectToAction("Service", "SimService");
        }

        private bool SimCardExists(int id)
        {
            return _context.SimCards.Any(e => e.Id == id);
        }
    }
}
