using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Plantify_Project_The_Webshop.Data;
using Plantify_Project_The_Webshop.Models;

namespace Plantify_Project_The_Webshop.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext database;
        private readonly AccessControl accessControl;
        public IndexModel(AppDbContext database, AccessControl accessControl)
        {
            this.database = database;
            this.accessControl = accessControl;
        }

        public List<Product> Products { get; set; }
        public Account Account { get; set; }
        public Cart Carts { get; set; }


        //Variabler
        public string searchText { get; set; }
        public string category { get; set; }

        private int PageSize = 10;
        public int PageIndex { get; set; } = 0;
        

        //Metoder
        private void Setup()
        {
            Products = database.Products.ToList();
        }

        public void OnGet(string searchText, string category, int pageIndex) // alt ?pageIndex
        {
            Setup();

            if(searchText != null) 
            {
                Products = Products.Where(p => p.Name.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            }

            if(category != null && category != "All Categories") 
            { 
                Products = Products.Where(p => p.Category == category).ToList();
            }

            PageIndex = pageIndex; // alt pageIndex ?? 0;
            Products = Products.Skip(PageIndex * PageSize).Take(PageSize).ToList();

        }

        public ActionResult OnPostPrevious(string searchText, string category)
        {
            PageIndex = Math.Max(0, PageIndex - 1);
            return RedirectToPage(new {searchText, category, pageIndex = PageIndex });
        }

        public ActionResult OnPostNext(string searchText, string category)
        {
            PageIndex+= 1;
            return RedirectToPage(new {searchText, category, pageIndex = PageIndex});
        }

    }
}