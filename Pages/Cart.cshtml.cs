using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Storage;
using Plantify_Project_The_Webshop.Data;
using Plantify_Project_The_Webshop.Models;
using System.Collections.Generic;
using System.Linq;

namespace Plantify_Project_The_Webshop.Pages
{
    public class CartModel : PageModel
    {
        //Konstruktorer
        public List<Cart> Cart { get; set; }  // Definierar Cart-egenskapen
        public Product Product { get; set; }

        //Variabler
        public int CountItems { get; set; }
        public double TotalPrice { get; set; }
        public string emptyCart { get; set; }

        //Metoder
        public void GetCartItems()
        {
            if (Cart == null || !Cart.Any())
            {
                emptyCart = "Your cart is empty!";
            }

            else
            {
                // l�gg till kod f�r att visa om saker finns i ens cart
            }
        }

        public void CountCartItems() //R�kna antalet produkter i varukorgen
        {
            CountItems = Cart.Sum(cart => cart.Quantity);
        }

        public double CalculateTotalPrice() //R�kna ut totala priset av produkterna i varukorgen
        {
            TotalPrice = Cart.Sum(cart => cart.Products.Price * cart.Quantity);
            return TotalPrice;
        }


        public void OnGet(List<Cart> carts) //Anropa ovan metoder f�r att samla och presentera inneh�llet i varukorgen
        {
            Cart = carts; // Tilldela v�rden till Cart-egenskapen
            GetCartItems();
            CalculateTotalPrice();
            CountCartItems();
        }
    }
}
