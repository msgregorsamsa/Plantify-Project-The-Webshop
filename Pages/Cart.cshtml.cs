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
            //Anropa nedan metoder n�r de �r skapade
        }

        // Implementera en metod f�r att h�mta produkter fr�n kundvagnen

        // Implementera en metod f�r att ber�kna det totala priset f�r produkterna i kundvagnen

    }
}
