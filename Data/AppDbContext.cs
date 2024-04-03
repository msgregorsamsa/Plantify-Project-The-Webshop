using Microsoft.EntityFrameworkCore;
using Plantify_Project_The_Webshop.Models;
using System.Collections.Generic;

namespace Plantify_Project_The_Webshop.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    }
}
