using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Plantify_Project_The_Webshop.Data;
using Plantify_Project_The_Webshop.Models;

namespace Plantify_Project_The_Webshop.Pages
{
    public class DetailsModel : PageModel
    {
       //Databas
        private readonly AppDbContext database;
        private readonly AccessControl accessControl;

        public DetailsModel(AppDbContext database, AccessControl accessControl)
        {
            this.database = database;
            this.accessControl = accessControl;
        }

        //Variabler
        public Product Product { get; set; }

        //Metoder
        private Product GetProductById(int id)
        {
            return Product = database.Products.First(p => p.ID == id);
        }

        public void OnGet(int id) // Hämtar detaljer för en specifik produkt baserat på ID. 
        {
            Product = GetProductById(id);
        }

        public IActionResult OnPost(int id)
        {
            Product = GetProductById(id);

            if (Product != null)
            {
                // Skapa en ny cart som tillhör den nuvarande inloggade användare om minst en produkt blivit tillagd. 
                var newCartItem = new Cart { AccountID = accessControl.LoggedInAccountID,
                                             ProductId = id, //Ändra till productname?? 
                                             Quantity = 1};

                database.Carts.Add(newCartItem);
                database.SaveChanges();

                return RedirectToPage("/Cart");
            }
            else
            {
                return NotFound();
            }
        }
    }
}
