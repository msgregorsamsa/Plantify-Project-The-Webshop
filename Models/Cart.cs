namespace Plantify_Project_The_Webshop.Models
{
    public class Cart
    {
            public int Id { get; set; }
            public int AccountID { get; set; }
            public int ProductId { get; set; }
            public int Quantity { get; set; }
            public virtual Account Accounts { get; set; }
            public virtual Product Products { get; set; }
    }
}
