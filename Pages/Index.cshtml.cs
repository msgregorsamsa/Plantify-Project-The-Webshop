using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Plantify_Project_The_Webshop.Data;
using Plantify_Project_The_Webshop.Models;

namespace Plantify_Project_The_Webshop.Pages
{
    public class IndexModel : PageModel
    {
        //Databas
        private readonly AppDbContext database;
        private readonly AccessControl accessControl;
        public IndexModel(AppDbContext database, AccessControl accessControl)
        {
            this.database = database;
            this.accessControl = accessControl;
        }

        // Variabler
        public AccessControl AccessControl { get; set; } 
        public List<Product> Products { get; set; }
        public Account Account { get; set; }
        public Cart Carts { get; set; }

        public string searchText { get; set; }
        public string category { get; set; }

        public int PageSize = 10;

        public int TotalAmountOfProducts { get; set; }
        public int PageIndex { get; set; }

        // Metoder
        private void Setup()
        {
            Products = database.Products.ToList();
        }

        public void OnGet(string searchText, string category, int pageIndex)
        {
            Setup();

            this.searchText = searchText;
            this.category = category;

            if (searchText != null)
            {
                Products = Products.Where(p => p.Name.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            }

            if (category != null && category != "All Categories")
            {
                Products = Products.Where(p => p.Category == category).ToList();
            }
            TotalAmountOfProducts = Products.Count;
            PageIndex = pageIndex;
            Products = Products.Skip(PageIndex * PageSize).Take(PageSize).ToList();
        }

        public ActionResult OnPostPrevious(int pageIndex, string searchText, string category)
        {
            return RedirectToPage(new { searchText, category, PageIndex = pageIndex-1 });
        }

        public ActionResult OnPostNext(int pageIndex, string searchText, string category)
        {
            return RedirectToPage(new { searchText, category, PageIndex = pageIndex+1 });
        }
    }
}
