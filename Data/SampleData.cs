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
                        Price = 150,
                        Category = "Houseplants",
                        Description = "Hardy indoor plant known for its vertical, variegated leaves."
                    },
                    new Product
                    {
                        Name = "Fiddle Leaf Fig",
                        ImagePath = "fiddle_leaf_fig.jpg",
                        Price = 130,
                        Category = "Houseplants",
                        Description = "Trendy indoor tree with violin-shaped leaves."
                    },
                    new Product
                    {
                        Name = "Peace Lily",
                        ImagePath = "peace_lily.jpg",
                        Price = 95,
                        Category = "Houseplants",
                        Description = "Low-maintenance plant with elegant white flowers."
                    },
                    new Product
                    {
                        Name = "Spider Plant",
                        ImagePath = "spider_plant.jpg",
                        Price = 250,
                        Category = "Houseplants",
                        Description = "Air-purifying plant with long, arching leaves."
                    },
                    new Product
                    {
                        Name = "Pothos",
                        ImagePath = "pothos.jpg",
                        Price = 150,
                        Category = "Houseplants",
                        Description = "Easy-to-care-for trailing vine with heart-shaped leaves."
                    },
                    new Product
                    {
                        Name = "Aloe Vera",
                        ImagePath = "aloe_vera.jpg",
                        Price = 120,
                        Category = "Houseplants",
                        Description = "Succulent plant with soothing gel for skin care."
                    },
                    new Product
                    {
                        Name = "Philodendron",
                        ImagePath = "philodendron.jpg",
                        Price = 280,
                        Category = "Houseplants",
                        Description = "Popular indoor plant with heart-shaped leaves."
                    },
                    new Product
                    {
                        Name = "Chinese Money Plant",
                        ImagePath = "chinese_money_plant.jpg",
                        Price = 220,
                        Category = "Houseplants",
                        Description = "Unique plant with round, coin-shaped leaves."
                    },
                    new Product
                    {
                        Name = "Rubber Plant",
                        ImagePath = "rubber_plant.jpg",
                        Price = 210,
                        Category = "Houseplants",
                        Description = "Indoor tree with thick, glossy leaves."
                    },

                    //Pots/Vases
                    new Product
                    {
                        Name = "Terracotta Pot",
                        ImagePath = "terracotta_pot.jpg",
                        Price = 60,
                        Category = "Pots/Vases",
                        Description = "Classic terracotta pot for both indoor and outdoor plants."
                    },
                    new Product
                    {
                        Name = "Ceramic Planter",
                        ImagePath = "ceramic_planter.jpg",
                        Price = 180,
                        Category = "Pots/Vases",
                        Description = "A modern and classic ceramic pot for every occasion."
                    },
                    new Product
                    {
                        Name = "Hanging Discoball Flowerpot",
                        ImagePath = "hanging_basket.jpg",
                        Price = 250,
                        Category = "Pots/Vases",
                        Description = "An eye-catching disco ball pot that can turn any room into a party."
                    },
                    new Product
                    {
                        Name = "Plantable Pot",
                        ImagePath = "plantable_pot.jpg",
                        Price = 30,
                        Category = "Pots/Vases",
                        Description = "A plantable pot for those who want to grow from scratch on their own."
                    },
                    new Product
                    {
                        Name = "Large Pot",
                        ImagePath = "large_pot.jpg",
                        Price = 399,
                        Category = "Pots/Vases",
                        Description = "An impressive floor pot for your large plants."
                    },
                    new Product
                    {
                        Name = "Metal Plant Pot",
                        ImagePath = "metal_plant_pot.jpg",
                        Price = 100,
                        Category = "Pots/Vases",
                        Description = "Industrial-style metal pot for modern decor."
                    },
                    new Product
                    {
                        Name = "Metal plant pot with legs",
                        ImagePath = "pot_with_legs.jpg",
                        Price = 200,
                        Category = "Pots/Vases",
                        Description = "An elegant pot that raises your plant a little off the floor."
                    },
                    new Product
                    {
                        Name = "Golden pot",
                        ImagePath = "golden_pot.jpg",
                        Price = 140,
                        Category = "Pots/Vases",
                        Description = "A gold colored pot that creates a feeling of luxury in your home."
                    },
                    new Product
                    {
                        Name = "Round Vase",
                        ImagePath = "round_vase.jpg",
                        Price = 99,
                        Category = "Pots/Vases",
                        Description = "A small, stylish vase for smaller flower arrangements."
                    },
                    new Product
                    {
                        Name = "Fishbowl Vase",
                        ImagePath = "fishbowl_vase.jpg",
                        Price = 110,
                        Category = "Pots/Vases",
                        Description = "A classic glass bowl that resembles a fish bowl, perfect for all bouquets."
                    },

                    //Tools/Accessories
                    new Product
                    {
                        Name = "Gardening Gloves",
                        ImagePath = "gardening_gloves.jpg",
                        Price = 65,
                        Category = "Tools/Accessories",
                        Description = "Protective gloves for gardening tasks."
                    },
                    new Product
                    {
                        Name = "Pruning Shears",
                        ImagePath = "pruning_shears.jpg",
                        Price = 85,
                        Category = "Tools/Accessories",
                        Description = "Sharp shears for trimming plants."
                    },
                    new Product
                    {
                        Name = "Watering Can",
                        ImagePath = "watering_can.jpg",
                        Price = 40,
                        Category = "Tools/Accessories",
                        Description = "Essential tool for watering indoor plants."
                    },
                    new Product
                    {
                        Name = "Garden Tools",
                        ImagePath = "garden_tools.jpg",
                        Price = 75,
                        Category = "Tools/Accessories",
                        Description = "A set of three useful garden tools."
                    },
                    new Product
                    {
                        Name = "Plant Food",
                        ImagePath = "plant_food.jpg",
                        Price = 199,
                        Category = "Tools/Accessories",
                        Description = "Nutrient-rich food for healthy plant growth."
                    },
                    new Product
                    {
                        Name = "Soil Moisture Meter",
                        ImagePath = "soil_moisture_meter.jpg",
                        Price = 249,
                        Category = "Tools/Accessories",
                        Description = "Tool for measuring soil moisture levels."
                    },
                    new Product
                    {
                        Name = "Plant Mister",
                        ImagePath = "plant_mister.jpg",
                        Price = 125,
                        Category = "Tools/Accessories",
                        Description = "Handy mister for keeping humidity levels up."
                    },
                    new Product
                    {
                        Name = "Plant Labels",
                        ImagePath = "plant_labels.jpg",
                        Price = 25,
                        Category = "Tools/Accessories",
                        Description = "Labels for identifying different plants."
                    },
                    new Product
                    {
                        Name = "Glass container",
                        ImagePath = "cutting_jar.jpg",
                        Price = 30,
                        Category = "Tools/Accessories",
                        Description = "A glass container for your plant cuttings."
                    },
                    new Product
                    {
                        Name = "Repotting Mat",
                        ImagePath = "repotting_mat.jpg",
                        Price = 185,
                        Category = "Tools/Accessories",
                        Description = "A waterproof mat that reduces soiling and makes your replanting smooth and easy."
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
