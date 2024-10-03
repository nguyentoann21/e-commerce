using e_commerce_server.Models;

namespace e_commerce_server.DataAccess.OriginalData
{
    public class BabySizes
    {
        public static void BabySize (ApplicationDbContext context)
        {
            // Baby products sizes
            var babysize = new List<ProductSize>
            {
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Baby Small", ProductSizeDescription = "Small (0-6 months)" },
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Baby Medium", ProductSizeDescription = "Medium (6-12 months)" },
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Baby Large", ProductSizeDescription = "Large (12-24 months)" },
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Baby Extra Large", ProductSizeDescription = "Extra Large (Over 24 months)" }
            };
            context.ProductSizes.AddRange(babysize);
        }
    }
}
