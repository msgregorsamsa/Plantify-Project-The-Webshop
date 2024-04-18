using Microsoft.AspNetCore.Mvc.RazorPages;
using Plantify_Project_The_Webshop.Data;
using Plantify_Project_The_Webshop.Models;

namespace Plantify_Project_The_Webshop.Pages
{
    public class OrderConfirmationModel : PageModel
    {
        //Variabler
        public List<Cart> Carts { get; set; }
        public Product Product { get; set; }
        public double TotalPrice { get; set; }
        public int OrderNumber { get; set; }

        //Databas
        private readonly AppDbContext database;
        private readonly AccessControl accessControl;

        public OrderConfirmationModel(AppDbContext database, AccessControl accessControl)
        {
            this.database = database;
            this.accessControl = accessControl;
        }

        //Metoder
        static int GenerateOrdernummer(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max + 1);
        }

        public void OnGet(double totalPrice)
        {
            TotalPrice = totalPrice;
            OrderNumber = GenerateOrdernummer(24050, 25670);
        }
    }
}
