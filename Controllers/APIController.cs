using Microsoft.AspNetCore.Mvc;
using Plantify_Project_The_Webshop.Data;
using Plantify_Project_The_Webshop.Models;
using System.Web;

namespace Plantify_Project_The_Webshop.Controllers
{
    [Route("/api")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext database;

        public ProductController(AppDbContext database)
        {
            this.database = database;
        }

        [HttpGet]
        [Route("/products")]
        public ActionResult<List<Product>> GetProducts(
                                            [FromQuery] string? name = "",
                                            [FromQuery] string? category = "",
                                            [FromQuery] int pageIndex = 1)
        {
            IQueryable<Product> query = database.Products;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(p => p.Name == name);
            }

            if (!string.IsNullOrEmpty(category))
            {
                // eftersom vi har / i våra kategorinamn i databasen
                var urlFriendlyCategory = HttpUtility.UrlDecode(category); 
                query = query.Where(p =>p.Category == urlFriendlyCategory);
            }

            int pageSize = 10;
            int skipPages = (pageIndex - 1) * pageSize;
           
            var products = query
                    .Select(p => new
                    {
                        p.ID,
                        p.Name,
                        p.Price,
                        p.Category,
                        p.Description,
                        // presenterar en genererad imgpath url istället för bara "plantname.jpg"
                        imageURL = GeneratedImageURL(p.ImagePath) 
                    })
                .Skip(skipPages).Take(pageSize).ToList();

            if (products.Count == 0)
            {
                return NotFound();
            }

            return Ok(products);
        }

        private static string GeneratedImageURL(string imagePath)
        {
            string webpageURL = "https://localhost:5000/Images/";
            string imageURL = $"{webpageURL}{imagePath}";
            return imageURL;
        }
    }
}
