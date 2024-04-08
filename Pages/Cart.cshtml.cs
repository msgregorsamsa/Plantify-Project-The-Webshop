using Microsoft.AspNetCore.Mvc.RazorPages;
using Plantify_Project_The_Webshop.Models;
using System.Collections.Generic;
using System.Linq;

namespace Plantify_Project_The_Webshop.Pages
{
    public class CartModel : PageModel
    {
        public List<Cart> Cart { get; set; }  // Definierar Cart-egenskapen

        public int CountItems { get; set; }
        public double TotalPrice { get; set; }
        public string emptyCart { get; set; }

        public void GetCartItems()
        {
            if (Cart == null || !Cart.Any())
            {
                emptyCart = "Your cart is empty!";
            }
        }

        public double CalculateTotalPrice()
        {
            TotalPrice = Cart.Sum(cart => cart.Products.Price * cart.Quantity);
            return TotalPrice;
        }

        public void CountCartItems()
        {
            CountItems = Cart.Sum(cart => cart.Quantity);
        }

        public void OnGet(List<Cart> carts)
        {
            Cart = carts; // Tilldela värden till Cart-egenskapen
            GetCartItems();
            CalculateTotalPrice();
            CountCartItems();
        }
    }
}
