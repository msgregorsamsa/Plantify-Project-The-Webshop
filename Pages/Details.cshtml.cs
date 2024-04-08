using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Plantify_Project_The_Webshop.Data;
using Plantify_Project_The_Webshop.Models;
using System.Collections.Generic; 

namespace Plantify_Project_The_Webshop.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly AppDbContext database;
        public Product Product { get; set; }

        public DetailsModel(AppDbContext database)
        {
            this.database = database;
        }

        private Product GetProductById(int id)
        {
            return Product = database.Products.First(p => p.ID == id);
        }

        public void OnGet(int id) // Hämtar "details" för en specifik produkt baserat på ID. 
        { 
            Product = GetProductById(id);
        }

    }
}
