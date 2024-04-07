using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Plantify_Project_The_Webshop.Models;
using System.Collections.Generic; 

namespace Plantify_Project_The_Webshop.Pages
{
    public class DetailsModel : PageModel
    {
        public Product Product { get; set; }

        private Product GetProductById(int id)
        {
            // Implementera kod f�r att h�mta produkt fr�n databasen baserat p� id

            return null; //�ndra till returnering av produkten som h�mtas ur
        }

        public void OnGet(int id) // H�mtar "details" f�r en specifik produkt baserat p� ID. 
        { 
            Product = GetProductById(id); // Funktionen GetProductById() �r fiktiv och m�ste implementeras f�r att h�mta produktdata
        }

    }
}
