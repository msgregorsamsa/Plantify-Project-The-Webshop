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
        private readonly AccessControl accessControl;
        public Product Product { get; set; }

        public DetailsModel(AppDbContext database, AccessControl accessControl)
        {
            this.database = database; //F�r att f� �tkomst till databasen och accesskontrollen i detta scope
            this.accessControl = accessControl;
        }

        private Product GetProductById(int id)
        {
            return Product = database.Products.First(p => p.ID == id);
        }

        public void OnGet(int id) // H�mtar detaljer f�r en specifik produkt baserat p� ID. 
        {
            Product = GetProductById(id);
        }

        public IActionResult OnPost(int id) //L�gg till en vara i varukurgen
        {
            Product = GetProductById(id);

            if (Product != null)
            {
                // Skapa en ny cart som tillh�r den nuvarande inloggade anv�ndare om minst en produkt blivit tillagd. 
                var newCartItem = new Cart { AccountID = accessControl.LoggedInAccountID,
                                             ProductId = id, //�ndra till productname?? 
                                             Quantity = 1};

                // L�gg till varan i databasen (varukorgen)
                database.Carts.Add(newCartItem);

                // Spara varan i databasen (varukorgen) 
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
