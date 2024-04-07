using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Plantify_Project_The_Webshop.Models;
using System.Collections.Generic; 

namespace Plantify_Project_The_Webshop.Pages
{
    public class DetailsModel : PageModel
    {
        public Product Product { get; set; }

        private Product GetProductById(int id)
        {
            // Implementera kod för att hämta produkt från databasen baserat på id

            return null; //Ändra till returnering av produkten som hämtas ur
        }

        public void OnGet(int id) // Hämtar "details" för en specifik produkt baserat på ID. 
        { 
            Product = GetProductById(id); // Funktionen GetProductById() är fiktiv och måste implementeras för att hämta produktdata
        }

    }
}
