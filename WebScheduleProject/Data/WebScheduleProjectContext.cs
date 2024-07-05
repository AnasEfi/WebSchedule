using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebScheduleProject.Models;
using System.Data;
using SQLitePCL;
// Класс контекста данных
namespace WebScheduleProject.Data
{
    public class WebScheduleProjectContext : DbContext
    {
        readonly StreamWriter logStream = new StreamWriter("DbLog.txt", true);
        public WebScheduleProjectContext(DbContextOptions<WebScheduleProjectContext> options)
            : base(options)
        {
           
        }

        public DbSet<WebScheduleProject.Models.User> Users { get; set; } = null!;
        public DbSet<WebScheduleProject.Models.SimCard> SimCards { get; set; } = null!;
        public DbSet<WebScheduleProject.Models.Service> Services { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(logStream.WriteLine);
        }

        public override void Dispose()
        {
            base.Dispose();
            logStream.Dispose();
        }

        public override async ValueTask DisposeAsync()
        {
            await base.DisposeAsync();
            await logStream.DisposeAsync();
        }
    }

}