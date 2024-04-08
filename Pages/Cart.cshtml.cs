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

            else
            {

            }
        }

        public void CountCartItems() //Räkna antalet produkter i varukorgen
        {
            CountItems = Cart.Sum(cart => cart.Quantity);
        }

        public double CalculateTotalPrice() //Räkna ut totala priset av produkterna i varukorgen
        {
            TotalPrice = Cart.Sum(cart => cart.Products.Price * cart.Quantity);
            return TotalPrice;
        }



        public void OnGet(List<Cart> carts) //Anropa ovan metoder för att samla och presentera innehållet i varukorgen
        {
            Cart = carts; // Tilldela värden till Cart-egenskapen
            GetCartItems();
            CalculateTotalPrice();
            CountCartItems();
        }

        public void OnPost() //Add to cart
        {
             
            int productId = int.Parse(Request.Form["productId"]);

/*            List<Product> ListOfItems = new List<Product>();
            Product = GetProductById(id);
            ListOfItems.Add(Product);*/

            return null;
        }
    }
}
