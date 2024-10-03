using e_commerce_server.Models;

namespace e_commerce_server.DataAccess.OriginalData
{
    public class SeedCategories
    {
        public static void SeedCategory(ApplicationDbContext context)
        {
            // Seed categories
            var categories = new List<Category>() {
                new Category { CategoryId = Guid.NewGuid(), CategoryName = "Clothes", CategoryDescription = "A category featuring various types of apparel for all genders and ages", CategoryImage = "categories/clothes.png" },
                new Category { CategoryId = Guid.NewGuid(), CategoryName = "Electronics", CategoryDescription = "A category offering the latest gadgets and devices, including smartphones, laptops, and home appliances", CategoryImage = "categories/electronics.png" },
                new Category { CategoryId = Guid.NewGuid(), CategoryName = "Home & Kitchen", CategoryDescription = "Products for home improvement and cooking essentials, from furniture to kitchenware", CategoryImage = "categories/home_and_kitchen.png" },
                new Category { CategoryId = Guid.NewGuid(), CategoryName = "Beauty & Personal Care", CategoryDescription = "A range of skincare, makeup, and grooming products to enhance beauty and wellness", CategoryImage = "categories/beauty_and_personal_care.png" },
                new Category { CategoryId = Guid.NewGuid(), CategoryName = "Sports & Outdoors", CategoryDescription = "Gear and apparel for fitness, sports, and outdoor adventures", CategoryImage = "categories/sports_and_outdoors.png" },
                new Category { CategoryId = Guid.NewGuid(), CategoryName = "Books & Stationery", CategoryDescription = "A collection of books, notebooks, and office supplies for learning and productivity", CategoryImage = "categories/books_and_stationery.png" },
                new Category { CategoryId = Guid.NewGuid(), CategoryName = "Toys & Games", CategoryDescription = "Fun and educational toys and games for children of all ages", CategoryImage = "categories/toys_and_games.png" },
                new Category { CategoryId = Guid.NewGuid(), CategoryName = "Health & Wellness", CategoryDescription = "Supplements, fitness equipment, and health products for a balanced lifestyle", CategoryImage = "categories/health_and_wellness.png" },
                new Category { CategoryId = Guid.NewGuid(), CategoryName = "Automotive", CategoryDescription = "Car accessories and maintenance tools to keep vehicles running smoothly", CategoryImage = "categories/automotive.png" },
                new Category { CategoryId = Guid.NewGuid(), CategoryName = "Jewelry & Accessories", CategoryDescription = "Stylish jewelry and fashion accessories for everyday wear or special occasions", CategoryImage = "categories/jewelry_and_accessories.png" },
                new Category { CategoryId = Guid.NewGuid(), CategoryName = "Furniture", CategoryDescription = "Functional and stylish furniture pieces to enhance any living space", CategoryImage = "categories/furniture.png" },
                new Category { CategoryId = Guid.NewGuid(), CategoryName = "Groceries", CategoryDescription = "A wide selection of everyday food and household essentials", CategoryImage = "categories/groceries.png" },
                new Category { CategoryId = Guid.NewGuid(), CategoryName = "Pet Supplies", CategoryDescription = "Everything needed to care for pets, from food to toys", CategoryImage = "categories/pet_supplies.png" },
                new Category { CategoryId = Guid.NewGuid(), CategoryName = "Baby Products", CategoryDescription = "Safe and reliable products for babies, including clothing, toys, and care items", CategoryImage = "categories/baby_products.png" },
                new Category { CategoryId = Guid.NewGuid(), CategoryName = "Footwear", CategoryDescription = "Shoes for all occasions, offering comfort and style for men, women, and children", CategoryImage = "categories/footwear.png" }
            };
            context.Categories.AddRange(categories);
        }
    }
}
