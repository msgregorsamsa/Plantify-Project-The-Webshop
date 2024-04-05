using Plantify_Project_The_Webshop.Models;

namespace Plantify_Project_The_Webshop.Data
{
    public class SampleData
    {

        public static void Create(AppDbContext database)
        {
            CreateAccount(database);
            CreateProduct(database);
        }

        public static void CreateProduct(AppDbContext database)
        {

            if (!database.Products.Any()) //Kontrollera om datan redan finns i databasen, om den inte gör det, lägg till. 
            {

                database.Products.AddRange(

                    //Plants
                    new Product
                    {
                        Name = "Monstera Deliciosa",
                        ImagePath = "monstera.jpg",
                        Price = 200,
                        Category = "Houseplants",
                        Description = "A popular houseplant known for its distinctive leaves."
                    }, new Product
                    {
                        Name = "Snake Plant",
                        ImagePath = "snake_plant.jpg",
                        Price = 25,
                        Category = "Houseplants",
                        Description = "Hardy indoor plant known for its vertical, variegated leaves."
                    },
                    new Product
                    {
                        Name = "Fiddle Leaf Fig",
                        ImagePath = "fiddle_leaf_fig.jpg",
                        Price = 50,
                        Category = "Houseplants",
                        Description = "Trendy indoor tree with violin-shaped leaves."
                    },
                    new Product
                    {
                        Name = "Peace Lily",
                        ImagePath = "peace_lily.jpg",
                        Price = 30,
                        Category = "Houseplants",
                        Description = "Low-maintenance plant with elegant white flowers."
                    },
                    new Product
                    {
                        Name = "Spider Plant",
                        ImagePath = "spider_plant.jpg",
                        Price = 20,
                        Category = "Houseplants",
                        Description = "Air-purifying plant with long, arching leaves."
                    },
                    new Product
                    {
                        Name = "Pothos",
                        ImagePath = "pothos.jpg",
                        Price = 15,
                        Category = "Houseplants",
                        Description = "Easy-to-care-for trailing vine with heart-shaped leaves."
                    },
                    new Product
                    {
                        Name = "Aloe Vera",
                        ImagePath = "aloe_vera.jpg",
                        Price = 12,
                        Category = "Houseplants",
                        Description = "Succulent plant with soothing gel for skin care."
                    },
                    new Product
                    {
                        Name = "Philodendron",
                        ImagePath = "philodendron.jpg",
                        Price = 18,
                        Category = "Houseplants",
                        Description = "Popular indoor plant with heart-shaped leaves."
                    },
                    new Product
                    {
                        Name = "Chinese Money Plant",
                        ImagePath = "chinese_money_plant.jpg",
                        Price = 22,
                        Category = "Houseplants",
                        Description = "Unique plant with round, coin-shaped leaves."
                    },
                    new Product
                    {
                        Name = "Rubber Plant",
                        ImagePath = "rubber_plant.jpg",
                        Price = 28,
                        Category = "Houseplants",
                        Description = "Indoor tree with thick, glossy leaves."
                    },

                    //Pots
                    new Product
                    {
                        Name = "Terracotta Pot",
                        ImagePath = "terracotta_pot.jpg",
                        Price = 10,
                        Category = "Pots",
                        Description = "Classic terracotta pot for indoor plants."
                    },
                    new Product
                    {
                        Name = "Ceramic Planter",
                        ImagePath = "ceramic_planter.jpg",
                        Price = 18,
                        Category = "Pots",
                        Description = "Modern ceramic planter with drainage hole."
                    },
                    new Product
                    {
                        Name = "Hanging Basket",
                        ImagePath = "hanging_basket.jpg",
                        Price = 25,
                        Category = "Pots",
                        Description = "Woven hanging basket for trailing plants."
                    },
                    new Product
                    {
                        Name = "Self-Watering Pot",
                        ImagePath = "self_watering_pot.jpg",
                        Price = 30,
                        Category = "Pots",
                        Description = "Pot with built-in reservoir for easy plant care."
                    },
                    new Product
                    {
                        Name = "Decorative Plant Stand",
                        ImagePath = "decorative_plant_stand.jpg",
                        Price = 35,
                        Category = "Pots",
                        Description = "Stylish plant stand for displaying indoor plants."
                    },
                    new Product
                    {
                        Name = "Metal Plant Pot",
                        ImagePath = "metal_plant_pot.jpg",
                        Price = 20,
                        Category = "Pots",
                        Description = "Industrial-style metal pot for modern decor."
                    },

                    //Tools/Accessories
                    new Product
                    {
                        Name = "Gardening Gloves",
                        ImagePath = "gardening_gloves.jpg",
                        Price = 12,
                        Category = "Tools/Accessories",
                        Description = "Protective gloves for gardening tasks."
                    },
                    new Product
                    {
                        Name = "Pruning Shears",
                        ImagePath = "pruning_shears.jpg",
                        Price = 15,
                        Category = "Tools/Accessories",
                        Description = "Sharp shears for trimming plants."
                    },
                    new Product
                    {
                        Name = "Watering Can",
                        ImagePath = "watering_can.jpg",
                        Price = 20,
                        Category = "Tools/Accessories",
                        Description = "Essential tool for watering indoor plants."
                    },
                    new Product
                    {
                        Name = "Misting Bottle",
                        ImagePath = "misting_bottle.jpg",
                        Price = 10,
                        Category = "Tools/Accessories",
                        Description = "Spray bottle for misting indoor plants."
                    },
                    new Product
                    {
                        Name = "Plant Food",
                        ImagePath = "plant_food.jpg",
                        Price = 8,
                        Category = "Tools/Accessories",
                        Description = "Nutrient-rich food for healthy plant growth."
                    },
                    new Product
                    {
                        Name = "Soil Moisture Meter",
                        ImagePath = "soil_moisture_meter.jpg",
                        Price = 15,
                        Category = "Tools/Accessories",
                        Description = "Tool for measuring soil moisture levels."
                    },
                    new Product
                    {
                        Name = "Plant Mister",
                        ImagePath = "plant_mister.jpg",
                        Price = 12,
                        Category = "Tools/Accessories",
                        Description = "Handy mister for keeping humidity levels up."
                    },
                    new Product
                    {
                        Name = "Plant Labels",
                        ImagePath = "plant_labels.jpg",
                        Price = 5,
                        Category = "Tools/Accessories",
                        Description = "Labels for identifying different plants."
                    },
                    new Product
                    {
                        Name = "Plant Stand",
                        ImagePath = "plant_stand.jpg",
                        Price = 30,
                        Category = "Tools/Accessories",
                        Description = "Stylish stand for displaying potted plants."
                    });
            }

            database.SaveChanges();
        }

        public static void CreateAccount(AppDbContext database)
        {
            // If there are no fake accounts, add some.
            string fakeIssuer = "https://example.com";
            if (!database.Accounts.Any(a => a.OpenIDIssuer == fakeIssuer))
            {
                var account = new Account
                {
                    OpenIDIssuer = fakeIssuer,
                    OpenIDSubject = "1111111111",
                    Name = "Test Testsson",
                    Email = "test.testsson@example.com",
                    Phone = "0738391854"
                };

                database.Accounts.Add(account);
                database.SaveChanges();
            }
        }

    }
}
