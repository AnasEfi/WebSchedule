using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using WebScheduleProject.Data;
using WebScheduleProject.Migrations;
using WebScheduleProject.Models;

namespace WebScheduleProject.Controllers
{
    public class ServiceController : Controller
    {
        private readonly WebScheduleProjectContext _context;
        public ServiceController(WebScheduleProjectContext context)
        {
            _context = context;
        }
        public static async Task<int> GetIdOfServiceByNameStatic(WebScheduleProjectContext context, string name)
        {
            try
            {
                // Попытка найти сервис по имени
                var service = await context.Services.FirstOrDefaultAsync(s => s.ServiceName == name);

                if (service == null)
                {
                    return -1;
                }
                else
                    return service.Id;
                          
            }
            catch (Exception ex)
            {
                // Обработка исключений, например, логирование ошибки
                Console.WriteLine($"Error: {ex.Message}");
                return -1; // Возвращаем -1 или другое значение, указывающее на ошибку
            }
        }

        public static async void AddServiceInDb(WebScheduleProjectContext context, string name)
        {
           Service newService = new Service { ServiceName = name };
           context.Services.Add(newService);
           await context.SaveChangesAsync();
        }
    }
}
