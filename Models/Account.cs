namespace Plantify_Project_The_Webshop.Models
{
    public class Account
    {
        public int ID { get; set; }
        public string OpenIDIssuer { get; set; }
        public string OpenIDSubject { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        //Skapa ett cart-objekt här?
    }
}
