using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Plantify_Project_The_Webshop.Data;
using Plantify_Project_The_Webshop.Models;

namespace Plantify_Project_The_Webshop.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext database;
        private readonly AccessControl accessControl;

        // Dessa är tomma och behöver "laddas" i setup av databasen
        public List<Product> Products { get; set; }
        public Account Account { get; set; }
        public Cart Carts { get; set; }



        public IndexModel(AppDbContext database, AccessControl accessControl)
        {
            this.database = database;
            this.accessControl = accessControl;
        }

        private void Setup()
        {
            Products = database.Products.ToList();
            //Carts = database.Carts.ToList();
        }

        public void OnGet()
        {
            Setup();
        }
    }
}