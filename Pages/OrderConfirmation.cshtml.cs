using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Plantify_Project_The_Webshop.Pages
{
    public class OrderConfirmationModel : PageModel
    {
        public decimal TotalPrice { get; set; }

        public void OnGet()
        //Implementera en metod som räknar ut och presenterar det totala priset av användarens order
        {
        }
    }
}
