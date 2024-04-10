using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Plantify_Project_The_Webshop.Data;
using Plantify_Project_The_Webshop.Models;

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

		//Databas
        private readonly AppDbContext database;
        private readonly AccessControl accessControl;

        public CartModel(AppDbContext database, AccessControl accessControl) //För att få åtkomst till databasen och accesskontrollen i detta scope
        {
            this.database = database;
            this.accessControl = accessControl;
        }

		//Metoder
		public List<Cart> GetCartItems()
		{
			// Hämta alla varukorgsobjekt för den inloggade användaren inklusive produktinformation
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

		public void CountCartItems() 
        {
            CountItems = Carts.Sum(cart => cart.Quantity);
        }

        public double CalculateTotalPrice() 
        {
            TotalPrice = Carts.Sum(cart => cart.Products.Price * cart.Quantity);
            return TotalPrice;
        }

		public ActionResult OnPostClearCart()
		{
			//Återanvänder koden som är för att hämta in alla varor i en varukorg
			var cartItems = database.Carts
				.Where(c => c.AccountID == accessControl.LoggedInAccountID)
				.ToList();

			if (cartItems != null && cartItems.Any())
			{
				database.Carts.RemoveRange(cartItems);
				database.SaveChanges();

			}

			return RedirectToPage("/Index");
		}

		public void OnGet()
		{
			Carts = GetCartItems();

			//Kontrollerar om varukorgen är tom innan den genomför några beräkningar
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
