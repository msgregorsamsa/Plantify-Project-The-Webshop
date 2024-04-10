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
        public IndexModel(AppDbContext database, AccessControl accessControl)
        {
            this.database = database;
            this.accessControl = accessControl;
        }

        public List<Product> Products { get; set; }
        public Account Account { get; set; }
        public Cart Carts { get; set; }


        //Variabler
        public string searchText { get; set; }
        public string category { get; set; }
        

        //Metoder
        private void Setup()
        {
            Products = database.Products.ToList();
        }

        public void OnGet(string searchText, string category)
        {
            Setup();

            if(searchText != null) 
            {
                Products = Products.Where(p => p.Name.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            }

            if(category != null && category != "All Categories") 
            { 
                Products = Products.Where(p => p.Category == category).ToList();
            }

        }


    }
}