using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;
using Plantify_Project_The_Webshop.Data;
using Plantify_Project_The_Webshop.Migrations;
using Plantify_Project_The_Webshop.Models;
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

        //En enda endpoint som returnerar en lista med produkter
        [HttpGet]
        [Route("/products")]
        public List<Product> GetProducts()
        {
            return database.Products.ToList();

            //if-sats till max 10 produkter
        }

        //Filtreringsmöjlighet på namn och kategori

        [HttpGet]
        [Route("/products/{name}")]
        public ActionResult GetProductByName(string name)
        {
            Product product = database.Products.FirstOrDefault(p => p.Name == name);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpGet]
        [Route("/products/{category}")]
        public ActionResult GetProductsByCategory(string category)
        {
            bool categoryExists = database.Products.Any(p => p.Category == category);

            if (categoryExists)
            {
                List<Product> products = 
                    database.Products.Where(p => p.Category == category).ToList();
                return Ok(products);
            }

            return NotFound();
            
        }
        //10 produkter ska returneras per gång med parameter för sidnummer

        //Varje produkt ska ha namn, bild, pris, kategori och beskrivning

        //Bilderna ska ha fungerande url:er som leder till hemsidan
    }
}
