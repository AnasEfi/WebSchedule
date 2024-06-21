using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebScheduleProject.Models;

namespace WebScheduleProject.Data
{
    public class WebScheduleProjectContext : DbContext
    {
        public WebScheduleProjectContext (DbContextOptions<WebScheduleProjectContext> options)
            : base(options)
        {
        }

        public DbSet<WebScheduleProject.Models.User> User { get; set; } = default!;
    }
}
