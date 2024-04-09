using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Plantify_Project_The_Webshop.Data;
using Plantify_Project_The_Webshop.Models;

using System.Collections.Generic;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Plantify_Project_The_Webshop.Pages
{
    public class CartModel : PageModel
    {

        //Variabler
        public List<Cart> Carts { get; set; } 
        public Product Product { get; set; }


        public int CountItems { get; set; }
        public double TotalPrice { get; set; }
        public string emptyCart { get; set; }

        private readonly AppDbContext database;
        private readonly AccessControl accessControl;

        public CartModel(AppDbContext database, AccessControl accessControl) //F�r att f� �tkomst till databasen och accesskontrollen i detta scope
        {
            this.database = database;
            this.accessControl = accessControl;
        }

		//Metoder
		public List<Cart> GetCartItems()
		{
			// H�mta alla varukorgsobjekt f�r den inloggade anv�ndaren inklusive produktinformation
			var cartItems = database.Carts
				.Where(cart => cart.AccountID == accessControl.LoggedInAccountID)
				.Include(cart => cart.Products) 
				.ToList();

			if (cartItems != null)
			{
				return cartItems;
			}
			else
			{
				emptyCart = "Your cart is empty!";
				return null;
			}
		}


		public void CountCartItems() //R�kna antalet produkter i varukorgen
        {
            CountItems = Carts.Sum(cart => cart.Quantity);
        }

        public double CalculateTotalPrice() //R�kna ut totala priset av produkterna i varukorgen
        {
            TotalPrice = Carts.Sum(cart => cart.Products.Price * cart.Quantity);
            return TotalPrice;
        }


		public void OnGet()
		{
			Carts = GetCartItems();

			// Kontrollera om varukorgen inte �r tom innan du utf�r ber�kningar
			if (Carts != null && Carts.Any())
			{
				CalculateTotalPrice();
				CountCartItems();
			}
			else
			{
				emptyCart = "Your cart is empty!";
			}
		}
	}
}
