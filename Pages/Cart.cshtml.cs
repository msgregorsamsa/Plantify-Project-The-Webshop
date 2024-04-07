using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Plantify_Project_The_Webshop.Models;
using System.Collections.Generic; 

namespace Plantify_Project_The_Webshop.Pages
{
    public class CartModel : PageModel
    {
        public List<Product> Cart { get; set; }
        public decimal TotalPrice { get; set; } 

        public void OnGet()
        {
            //Anropa nedan metoder när de är skapade
        }

        // Implementera en metod för att hämta produkter från kundvagnen

        // Implementera en metod för att beräkna det totala priset för produkterna i kundvagnen

    }
}
