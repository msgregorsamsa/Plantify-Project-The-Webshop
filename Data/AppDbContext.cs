using Microsoft.EntityFrameworkCore;
using Plantify_Project_The_Webshop.Models;

namespace Plantify_Project_The_Webshop.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Konfigurerar en FK för relationen mellan Account och Product
            modelBuilder.Entity<Cart>()
                .HasOne(a => a.Accounts)
                .WithMany(c => c.Carts)
                .OnDelete(DeleteBehavior.Cascade); // Om ett konto tas bort så tas alla kopplade produkter i kundkorgen även bort
            modelBuilder.Entity<Cart>()
                .HasOne(a => a.Products)
                .WithMany(p => p.Carts)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}