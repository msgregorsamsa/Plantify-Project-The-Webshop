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
        public List<Product> GetProducts()
        {
            return database.Products.ToList();

            //if-sats till max 10 produkter
        }


        [HttpGet]
        [Route("{name}")]
        public ActionResult<Product> GetProductByName(string name)
        {

            var product = database.Products.FirstOrDefault(p => p.Name == name);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpGet]
        [Route("category/{category}")]
        public ActionResult<List<Product>> GetProductsByCategory(string category)
        {
            var urlFriendlyCategory = HttpUtility.UrlDecode(category);

            var product = database.Products.Where(p =>  p.Category == urlFriendlyCategory).ToList();

            if(product.Count == 0)
            {
                return NotFound();
            }

            return Ok(product);
        }

        //10 produkter ska returneras per gång med parameter för sidnummer

        //Varje produkt ska ha namn, bild, pris, kategori och beskrivning

        //Bilderna ska ha fungerande url:er som leder till hemsidan
    }
}
