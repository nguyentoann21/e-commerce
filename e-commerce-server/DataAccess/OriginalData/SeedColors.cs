using e_commerce_server.Models;

namespace e_commerce_server.DataAccess.OriginalData
{
    public class SeedColors
    {
        public static void SeedColor(ApplicationDbContext context)
        {
            // Colors
            var colors = new List<ProductColor> {
                new ProductColor { ProductColorId = Guid.NewGuid(), ProductColorName = "Red", ProductColorDescription = "Red" },
                new ProductColor { ProductColorId = Guid.NewGuid(), ProductColorName = "Blue", ProductColorDescription = "Blue" },
                new ProductColor { ProductColorId = Guid.NewGuid(), ProductColorName = "Green", ProductColorDescription = "Green" },
                new ProductColor { ProductColorId = Guid.NewGuid(), ProductColorName = "Yellow", ProductColorDescription = "Yellow" },
                new ProductColor { ProductColorId = Guid.NewGuid(), ProductColorName = "White", ProductColorDescription = "White" },
                new ProductColor { ProductColorId = Guid.NewGuid(), ProductColorName = "Black", ProductColorDescription = "Black" },
                new ProductColor { ProductColorId = Guid.NewGuid(), ProductColorName = "Gray", ProductColorDescription = "Gray" },
                new ProductColor { ProductColorId = Guid.NewGuid(), ProductColorName = "Brown", ProductColorDescription = "Brown" },
                new ProductColor { ProductColorId = Guid.NewGuid(), ProductColorName = "Pink", ProductColorDescription = "Pink" },
                new ProductColor { ProductColorId = Guid.NewGuid(), ProductColorName = "Orange", ProductColorDescription = "Orange" },
                new ProductColor { ProductColorId = Guid.NewGuid(), ProductColorName = "Pastel Green", ProductColorDescription = "Pastel Green" },
                new ProductColor { ProductColorId = Guid.NewGuid(), ProductColorName = "Pastel Pink", ProductColorDescription = "Pastel Pink" },
                new ProductColor { ProductColorId = Guid.NewGuid(), ProductColorName = "Pastel Yellow", ProductColorDescription = "Pastel Yellow" },
                new ProductColor { ProductColorId = Guid.NewGuid(), ProductColorName = "Pastel Peach", ProductColorDescription = "Pastel Peach" },
                new ProductColor { ProductColorId = Guid.NewGuid(), ProductColorName = "Pastel Red", ProductColorDescription = "Pastel Red" },
                new ProductColor { ProductColorId = Guid.NewGuid(), ProductColorName = "Pastel Black", ProductColorDescription = "Pastel Black" },
                new ProductColor { ProductColorId = Guid.NewGuid(), ProductColorName = "Light Purple", ProductColorDescription = "Light Purple" },
                new ProductColor { ProductColorId = Guid.NewGuid(), ProductColorName = "Avocado Green", ProductColorDescription = "Avocado Green" },
                new ProductColor { ProductColorId = Guid.NewGuid(), ProductColorName = "Mint Green", ProductColorDescription = "Mint Green" },
                new ProductColor { ProductColorId = Guid.NewGuid(), ProductColorName = "Lavender", ProductColorDescription = "Lavender" },
                new ProductColor { ProductColorId = Guid.NewGuid(), ProductColorName = "Baby Blue", ProductColorDescription = "Baby Blue" },
                new ProductColor { ProductColorId = Guid.NewGuid(), ProductColorName = "Neon", ProductColorDescription = "Neon" },
                new ProductColor { ProductColorId = Guid.NewGuid(), ProductColorName = "Red - Black", ProductColorDescription = "Red - Black" },
                new ProductColor { ProductColorId = Guid.NewGuid(), ProductColorName = "Blue - White", ProductColorDescription = "Blue - White" },
                new ProductColor { ProductColorId = Guid.NewGuid(), ProductColorName = "Green - Yellow", ProductColorDescription = "Green - Yellow" },
                new ProductColor { ProductColorId = Guid.NewGuid(), ProductColorName = "Black - Gray", ProductColorDescription = "Black - Gray" },
                new ProductColor { ProductColorId = Guid.NewGuid(), ProductColorName = "White - Gray", ProductColorDescription = "White - Gray" },
                new ProductColor { ProductColorId = Guid.NewGuid(), ProductColorName = "Pink - Gray", ProductColorDescription = "Pink - Gray" },
                new ProductColor { ProductColorId = Guid.NewGuid(), ProductColorName = "Orange - Blue", ProductColorDescription = "Orange - Blue" },
                new ProductColor { ProductColorId = Guid.NewGuid(), ProductColorName = "Green - Brown", ProductColorDescription = "Green - Brown" },
                new ProductColor { ProductColorId = Guid.NewGuid(), ProductColorName = "Red - Yellow", ProductColorDescription = "Red - Yellow" },
                new ProductColor { ProductColorId = Guid.NewGuid(), ProductColorName = "Blue - Green", ProductColorDescription = "Blue - Green" },
                new ProductColor { ProductColorId = Guid.NewGuid(), ProductColorName = "Blue - Black", ProductColorDescription = "Blue - Black" },
                new ProductColor { ProductColorId = Guid.NewGuid(), ProductColorName = "White - Black", ProductColorDescription = "White - Black" },
                new ProductColor { ProductColorId = Guid.NewGuid(), ProductColorName = "Red - White", ProductColorDescription = "Red - White" },
                new ProductColor { ProductColorId = Guid.NewGuid(), ProductColorName = "Gray - Black", ProductColorDescription = "Gray - Black" },
                new ProductColor { ProductColorId = Guid.NewGuid(), ProductColorName = "Yellow - Blue", ProductColorDescription = "Yellow - Blue" },
                new ProductColor { ProductColorId = Guid.NewGuid(), ProductColorName = "Multi-color", ProductColorDescription = "Multi-color" }
            };
            context.ProductColors.AddRange(colors);
        }
    }
}
