using e_commerce_server.Models;
using Microsoft.EntityFrameworkCore;

namespace e_commerce_server.DataAccess
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider service)
        {
            using(var context = new ApplicationDbContext(service.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.Categories.Any() && context.Roles.Any() && context.ProductSizes.Any())
                {
                    return;
                }

                //seed roles
                var roleUser = new Role { RoleId = Guid.NewGuid(), RoleName = "User", RoleDescription = "User is a role for the customer in the system" };
                var roleAdmin = new Role { RoleId = Guid.NewGuid(), RoleName = "Admin", RoleDescription = "Admin is the role of the admin/manager in the system" };
                var roleEmployee = new Role { RoleId = Guid.NewGuid(), RoleName = "Employee", RoleDescription = "Employee is a role for the staff in the system" };
                context.Roles.AddRange(roleUser, roleAdmin, roleEmployee);

                //seed categories
                var clothes = new Category { CategoryId = Guid.NewGuid(), CategoryName = "Clothes", CategoryDescription = "A category featuring various types of apparel for all genders and ages", CategoryImage = "categories/clothes.png" };
                var electronics = new Category { CategoryId = Guid.NewGuid(), CategoryName = "Electronics", CategoryDescription = "A category offering the latest gadgets and devices, including smartphones, laptops, and home appliances", CategoryImage = "categories/electronics .png" };
                var homeAndKitchen = new Category { CategoryId = Guid.NewGuid(), CategoryName = "Home & Kitchen", CategoryDescription = "Products for home improvement and cooking essentials, from furniture to kitchenware", CategoryImage = "categories/home_and_kitchen.png" };
                var beautyAnhPersonalCare = new Category { CategoryId = Guid.NewGuid(), CategoryName = "Beauty & Personal Care", CategoryDescription = "A range of skincare, makeup, and grooming products to enhance beauty and wellness", CategoryImage = "categories/beauty_and_personal_care.png" };
                var sportsAndOutdoors = new Category { CategoryId = Guid.NewGuid(), CategoryName = "Sports & Outdoors", CategoryDescription = "Gear and apparel for fitness, sports, and outdoor adventures", CategoryImage = "categories/sports_and_outdoors.png" };
                var booksAndStationery = new Category { CategoryId = Guid.NewGuid(), CategoryName = "Books & Stationery", CategoryDescription = "A collection of books, notebooks, and office supplies for learning and productivity", CategoryImage = "categories/books_and_stationery.png" };
                var toysAndGames = new Category { CategoryId = Guid.NewGuid(), CategoryName = "Toys & Games", CategoryDescription = "Fun and educational toys and games for children of all ages", CategoryImage = "categories/toys_and_games.png" };
                var healthAndWellness = new Category { CategoryId = Guid.NewGuid(), CategoryName = "Health & Wellness", CategoryDescription = "Supplements, fitness equipment, and health products for a balanced lifestyle", CategoryImage = "categories/health_and_wellness.png" };
                var automotive = new Category { CategoryId = Guid.NewGuid(), CategoryName = "Automotive", CategoryDescription = "Car accessories and maintenance tools to keep vehicles running smoothly", CategoryImage = "categories/automotive.png" };
                var jewelryAndAccessories = new Category { CategoryId = Guid.NewGuid(), CategoryName = "Jewelry & Accessories", CategoryDescription = "Stylish jewelry and fashion accessories for everyday wear or special occasions", CategoryImage = "categories/jewelry_and_accessories.png" };
                var furniture = new Category { CategoryId = Guid.NewGuid(), CategoryName = "Furniture", CategoryDescription = "Functional and stylish furniture pieces to enhance any living space", CategoryImage = "categories/furniture.png" };
                var groceries = new Category { CategoryId = Guid.NewGuid(), CategoryName = "Groceries", CategoryDescription = "A wide selection of everyday food and household essentials", CategoryImage = "categories/groceries.png" };
                var petSupplies = new Category { CategoryId = Guid.NewGuid(), CategoryName = "Pet Supplies", CategoryDescription = "Everything needed to care for pets, from food to toys", CategoryImage = "categories/pet_supplies.png" };
                var babyProducts = new Category { CategoryId = Guid.NewGuid(), CategoryName = "Baby Products", CategoryDescription = "Safe and reliable products for babies, including clothing, toys, and care items", CategoryImage = "categories/baby_products.png" };
                var footwear = new Category { CategoryId = Guid.NewGuid(), CategoryName = "Footwear", CategoryDescription = "Shoes for all occasions, offering comfort and style for men, women, and children", CategoryImage = "categories/footwear.png" };
                context.Categories.AddRange(clothes, electronics, homeAndKitchen, beautyAnhPersonalCare, sportsAndOutdoors, booksAndStationery, toysAndGames, healthAndWellness, automotive, jewelryAndAccessories, furniture, groceries, petSupplies, babyProducts, footwear);

                //seed all sizes
                //clothes male sizes
                var clothMaleSizeXS = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Male - XS", ProductSizeDescription = "XS(Under 40kg)" };
                var clothMaleSizeS = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Male - S", ProductSizeDescription = "S(45 - 50kg)" };
                var clothMaleSizeM = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Male - M", ProductSizeDescription = "M(50 - 55kg)" };
                var clothMaleSizeL = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Male - L", ProductSizeDescription = "L(55 - 65kg)" };
                var clothMaleSizeXL = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Male - XL", ProductSizeDescription = "XL(65 - 75kg)" };
                var clothMaleSizeXXL = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Male - XXL", ProductSizeDescription = "XXL(Over 75kg)" };

                //clothes female sizes
                var clothFemaleSizeXS = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Female - XS", ProductSizeDescription = "XS(Under 40kg)" };
                var clothFemaleSizeS = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Female - S", ProductSizeDescription = "S(45 - 50kg)" };
                var clothFemaleSizeM = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Female - M", ProductSizeDescription = "M(50 - 55kg)" };
                var clothFemaleSizeL = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Female - L", ProductSizeDescription = "L(55 - 60kg)" };
                var clothFemaleSizeXL = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Female - XL", ProductSizeDescription = "XL(60 - 70kg)" };
                var clothFemaleSizeXXL = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Female - XXL", ProductSizeDescription = "XXL(Over 70kg)" };

                // N/A sizes
                var noneSize = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "N/A", ProductSizeDescription = "Sizes vary by product type" };

                // One size
                var oneSize = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "One Size", ProductSizeDescription = "One size fits all for most products" };

                //baby products sizes
                var babyProductSmall = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Small", ProductSizeDescription = "Small (0-6 months)" };
                var babyProductMedium = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Medium", ProductSizeDescription = "Medium (6-12 months)" };
                var babyProductLarge = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Large", ProductSizeDescription = "Large (12-24 months)" };
                var babyProductExtra = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Extra Large", ProductSizeDescription = "Extra Large (Over 24 months)" };

                //volume sizes
                var volume_5 = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "5ml", ProductSizeDescription = "5ml" };
                var volume_10 = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "10ml", ProductSizeDescription = "10ml" };
                var volume_30 = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "30ml", ProductSizeDescription = "30ml" };
                var volume_100 = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "100ml", ProductSizeDescription = "100ml" };
                var volume_330 = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "330ml", ProductSizeDescription = "330ml" };
                var volume_360 = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "360ml", ProductSizeDescription = "360ml" };
                var volume_500 = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "500ml", ProductSizeDescription = "500ml" };
                var volume_1000 = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "1000ml", ProductSizeDescription = "1L" };
                var volume_1500 = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "1500ml", ProductSizeDescription = "1.5L" };
                var volume_2000 = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "2000ml", ProductSizeDescription = "2L" };
                var volume_3000 = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "3000ml", ProductSizeDescription = "3L" };
                var volume_5000 = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "5000ml", ProductSizeDescription = "5L" };
                var volume_10000 = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "10000ml", ProductSizeDescription = "10L" };
                var volume_30000 = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "30000ml", ProductSizeDescription = "30L" };

                // engine displacement, displacement volume sizes
                // motobikes
                var motobike_50 = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "50cc", ProductSizeDescription = "50cc" };
                var motobike_70 = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "70cc", ProductSizeDescription = "70cc" };
                var motobike_80 = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "80cc", ProductSizeDescription = "80cc" };
                var motobike_100 = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "100cc", ProductSizeDescription = "100cc" };
                var motobike_110 = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "110cc", ProductSizeDescription = "110cc" };
                var motobike_125 = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "125cc", ProductSizeDescription = "125cc" };
                var motobike_140 = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "140cc", ProductSizeDescription = "140cc" };
                var motobike_150 = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "150cc", ProductSizeDescription = "150cc" };
                var motobike_160 = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "160cc", ProductSizeDescription = "160cc" };
                var motobike_180 = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "180cc", ProductSizeDescription = "180cc" };
                var motobike_200 = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "200cc", ProductSizeDescription = "200cc" };
                var motobike_220 = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "220cc", ProductSizeDescription = "220cc" };
                var motobike_250 = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "250cc", ProductSizeDescription = "250cc" };
                var motobike_300 = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "300cc", ProductSizeDescription = "300cc" };
                var motobike_350 = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "350cc", ProductSizeDescription = "350cc" };
                var motobike_400 = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "400cc", ProductSizeDescription = "400cc" };
                var motobike_500 = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "500cc", ProductSizeDescription = "500cc" };
                var motobike_600 = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "600cc", ProductSizeDescription = "600cc" };
                var motobike_750 = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "750cc", ProductSizeDescription = "750cc" };
                var motobike_1000 = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "1000cc", ProductSizeDescription = "1000cc" };
                var motobike_1200 = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "1200cc", ProductSizeDescription = "1200cc" };
                var motobike_over_1200 = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Over 1200cc", ProductSizeDescription = "Over 1200cc" };

                //cars
                var car_1000 = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "1000cc", ProductSizeDescription = "1000cc" };
                var car_1200 = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "1200cc", ProductSizeDescription = "1200cc" };
                var car_1300 = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "1300cc", ProductSizeDescription = "1300cc" };
                var car_1400 = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "1400cc", ProductSizeDescription = "1400cc" };
                var car_1600 = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "1600cc", ProductSizeDescription = "1600cc" };
                var car_1800 = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "1800cc", ProductSizeDescription = "1800cc" };
                var car_2000 = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "2000cc", ProductSizeDescription = "2000cc" };
                var car_2200 = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "2200cc", ProductSizeDescription = "2200cc" };
                var car_2500 = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "2500cc", ProductSizeDescription = "2500cc" };
                var car_3000 = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "3000cc", ProductSizeDescription = "3000cc" };
                var car_3500 = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "3500cc", ProductSizeDescription = "3500cc" };
                var car_4000 = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "4000cc", ProductSizeDescription = "4000cc" };
                var car_5000 = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "5000cc", ProductSizeDescription = "5000cc" };
                var car_6000 = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "6000cc", ProductSizeDescription = "6000cc" };
                var car_7000 = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "7000cc", ProductSizeDescription = "7000cc" };
                var car_8000 = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "8000cc", ProductSizeDescription = "8000cc" };


                //electrics
                var electric_A = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "0.5 - 1 kW", ProductSizeDescription = "0.5 - 1 kW" };
                var electric_B = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "0.5 - 1.5kW", ProductSizeDescription = "0.5 - 1.5kW" };
                var electric_C = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "1 - 2 kW", ProductSizeDescription = "1 - 2 kW" };
                var electric_D = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "2 - 4 kW", ProductSizeDescription = "2 - 4 kW" };
                var electric_E = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "3 - 5 kW", ProductSizeDescription = "3 - 5 kW" };
                var electric_F = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "5 - 10 kW", ProductSizeDescription = "5 - 10 kW" };
                var electric_G = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "50 - 150 kW", ProductSizeDescription = "50 - 150 kW" };
                var electric_H = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "150 - 250 kW", ProductSizeDescription = "150 - 250 kW" };
                var electric_I = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "150 - 300 kW", ProductSizeDescription = "150 - 300 kW" };
                var electric_J = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "200 - 400 kW", ProductSizeDescription = "200 - 400 kW" };
            
                //normal sizes
                var small = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Small", ProductSizeDescription = "Small" };
                var medium = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Medium", ProductSizeDescription = "Medium" };
                var large = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Large", ProductSizeDescription = "Large" };
                var single = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Single", ProductSizeDescription = "Single" };
                var duo = new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Double", ProductSizeDescription = "Double" };
                context.ProductSizes.AddRange(clothMaleSizeXS, clothMaleSizeS, clothMaleSizeM, clothMaleSizeL, clothMaleSizeXL, clothMaleSizeXXL, 
                    clothFemaleSizeXS, clothFemaleSizeS, clothFemaleSizeM, clothFemaleSizeL, clothFemaleSizeXL, clothFemaleSizeXXL, noneSize, oneSize,
                    babyProductSmall, babyProductMedium, babyProductLarge, babyProductExtra, volume_5, volume_10, volume_30, volume_100, volume_330,
                    volume_360, volume_500, volume_1000, volume_1500, volume_2000, volume_3000, volume_5000, volume_10000, volume_30000,
                    motobike_50, motobike_70, motobike_80, motobike_100, motobike_110, motobike_125, motobike_140, motobike_150, motobike_160,
                    motobike_180, motobike_200, motobike_220, motobike_250, motobike_300, motobike_350, motobike_400, motobike_500, motobike_600,
                    motobike_750, motobike_1000, motobike_1200, motobike_over_1200, car_1000, car_1200, car_1300, car_1400, car_1600, car_1800, car_2000,
                    car_2200, car_2500, car_3000, car_3500, car_4000, car_5000, car_6000, car_7000, car_8000, electric_A, electric_B, electric_C, electric_D,
                    electric_E, electric_F, electric_G, electric_H, electric_I, electric_J, small, medium, large, single, duo);

                //colors
                var red = new ProductColor { ProductColorId = Guid.NewGuid(), ProductColorName = "Red", ProductColorDescription = "Red" };
                var blue = new ProductColor { ProductColorId = Guid.NewGuid(), ProductColorName = "Blue", ProductColorDescription = "Blue" };
                var green = new ProductColor { ProductColorId = Guid.NewGuid(), ProductColorName = "Green", ProductColorDescription = "Green" };
                var yellow = new ProductColor { ProductColorId = Guid.NewGuid(), ProductColorName = "Yellow", ProductColorDescription = "Yellow" };
                var white = new ProductColor { ProductColorId = Guid.NewGuid(), ProductColorName = "White", ProductColorDescription = "White" };
                var black = new ProductColor { ProductColorId = Guid.NewGuid(), ProductColorName = "Black", ProductColorDescription = "Black" };
                var gray = new ProductColor { ProductColorId = Guid.NewGuid(), ProductColorName = "Gray", ProductColorDescription = "Gray" };
                var brown = new ProductColor { ProductColorId = Guid.NewGuid(), ProductColorName = "Brown", ProductColorDescription = "Brown" };
                var pink = new ProductColor { ProductColorId = Guid.NewGuid(), ProductColorName = "Pink", ProductColorDescription = "Pink" };
                var orange = new ProductColor { ProductColorId = Guid.NewGuid(), ProductColorName = "Orange", ProductColorDescription = "Orange" };
                var pastelGreen = new ProductColor { ProductColorId = Guid.NewGuid(), ProductColorName = "Pastel Green", ProductColorDescription = "Pastel Green" };
                var pastelPink = new ProductColor { ProductColorId = Guid.NewGuid(), ProductColorName = "Pastel Pink", ProductColorDescription = "Pastel Pink" };
                var pastelYellow = new ProductColor { ProductColorId = Guid.NewGuid(), ProductColorName = "Pastel Yellow", ProductColorDescription = "Pastel Yellow" };
                var pastelPeach = new ProductColor { ProductColorId = Guid.NewGuid(), ProductColorName = "Pastel Peach", ProductColorDescription = "Pastel Peach" };
                var pastelRed = new ProductColor { ProductColorId = Guid.NewGuid(), ProductColorName = "Pastel Red", ProductColorDescription = "Pastel Red" };
                var pastelBlack = new ProductColor { ProductColorId = Guid.NewGuid(), ProductColorName = "Pastel Black", ProductColorDescription = "Pastel Black" };
                var lightPurple = new ProductColor { ProductColorId = Guid.NewGuid(), ProductColorName = "Light Purple", ProductColorDescription = "Light Purple" };
                var avocadoGreen = new ProductColor { ProductColorId = Guid.NewGuid(), ProductColorName = "Avocado Green", ProductColorDescription = "Avocado Green" };
                var mintGreen = new ProductColor { ProductColorId = Guid.NewGuid(), ProductColorName = "Mint Green", ProductColorDescription = "Mint Green" };
                var lavender = new ProductColor { ProductColorId = Guid.NewGuid(), ProductColorName = "Lavender", ProductColorDescription = "Lavender" };
                var babyBlue = new ProductColor { ProductColorId = Guid.NewGuid(), ProductColorName = "Baby Blue", ProductColorDescription = "Baby Blue" };
                var neon = new ProductColor { ProductColorId = Guid.NewGuid(), ProductColorName = "Neon", ProductColorDescription = "Neon" };
                var redBlack = new ProductColor { ProductColorId = Guid.NewGuid(), ProductColorName = "Red - Black", ProductColorDescription = "Red - Black" };
                var blueWhite = new ProductColor { ProductColorId = Guid.NewGuid(), ProductColorName = "Blue - White", ProductColorDescription = "Blue - White" };
                var greenYellow = new ProductColor { ProductColorId = Guid.NewGuid(), ProductColorName = "Green - Yellow", ProductColorDescription = "Green - Yellow" };
                var blackGray = new ProductColor { ProductColorId = Guid.NewGuid(), ProductColorName = "Black - Gray", ProductColorDescription = "Black - Gray" };
                var whiteGray = new ProductColor { ProductColorId = Guid.NewGuid(), ProductColorName = "White - Gray", ProductColorDescription = "White - Gray" };
                var pinkGray = new ProductColor { ProductColorId = Guid.NewGuid(), ProductColorName = "Pink - Gray", ProductColorDescription = "Pink - Gray" };
                var orangeBlue = new ProductColor { ProductColorId = Guid.NewGuid(), ProductColorName = "Orange - Blue", ProductColorDescription = "Orange - Blue" };
                var greenBrown = new ProductColor { ProductColorId = Guid.NewGuid(), ProductColorName = "Green - Brown", ProductColorDescription = "Green - Brown" };
                var redYellow = new ProductColor { ProductColorId = Guid.NewGuid(), ProductColorName = "Red - Yellow", ProductColorDescription = "Red - Yellow" };
                var blueGreen = new ProductColor { ProductColorId = Guid.NewGuid(), ProductColorName = "Blue - Green", ProductColorDescription = "Blue - Green" };
                var blueBlack = new ProductColor { ProductColorId = Guid.NewGuid(), ProductColorName = "Blue - Black", ProductColorDescription = "Blue - Black" };
                var whiteBlack = new ProductColor { ProductColorId = Guid.NewGuid(), ProductColorName = "White - Black", ProductColorDescription = "White - Black" };
                var redWhite = new ProductColor { ProductColorId = Guid.NewGuid(), ProductColorName = "Red - White", ProductColorDescription = "Red - White" };
                var grayBlack = new ProductColor { ProductColorId = Guid.NewGuid(), ProductColorName = "Gray - Black", ProductColorDescription = "Gray - Black" };
                var yellowBlue = new ProductColor { ProductColorId = Guid.NewGuid(), ProductColorName = "Yellow - Blue", ProductColorDescription = "Yellow - Blue" };
                var multiColor = new ProductColor { ProductColorId = Guid.NewGuid(), ProductColorName = "Multi-color", ProductColorDescription = "Multi-color" };
                context.ProductColors.AddRange(red, blue, green, yellow, white, black, gray, brown, pink, orange, pastelGreen, pastelPink, pastelYellow, pastelPeach, pastelRed,
                    pastelBlack, lightPurple, avocadoGreen, mintGreen, lavender, babyBlue, neon, redBlack, blueWhite, greenYellow, blackGray, whiteGray, pinkGray, orangeBlue, 
                    greenBrown, redYellow, blueGreen, blueBlack, whiteBlack, redWhite, grayBlack, yellowBlue, multiColor);
            }
        }
    }
}
