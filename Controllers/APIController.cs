using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;
using Plantify_Project_The_Webshop.Data;
using Plantify_Project_The_Webshop.Migrations;
using Plantify_Project_The_Webshop.Models;
using System.Web;
using System.Xml.Linq;

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
                var urlFriendlyCategory = HttpUtility.UrlDecode(category); // eftersom vi har / i våra kategorinamn i databasen
                query = query.Where(p =>p.Category == urlFriendlyCategory);
            }

            //Håller koll på sida och antal produkter per sida.
            int pageSize = 10;
            int skipPages = (pageIndex - 1) * pageSize;

            var products = query.Skip(skipPages).Take(pageSize).ToList();

            if(products.Count == 0)
            {
                return NotFound();
            }

            return Ok(products);
        }


        //Varje produkt ska ha namn, bild, pris, kategori och beskrivning

        //Bilderna ska ha fungerande url:er som leder till hemsidan
    }
}
