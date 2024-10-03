using e_commerce_server.Models;

namespace e_commerce_server.DataAccess.OriginalData
{
    public class SeedClothSizes
    {
        public static void SeedClothSize(ApplicationDbContext context)
        {
            // Seed all clothes sizes
            var clothes = new List<ProductSize> { 
                // Clothes male sizes
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Clothes Male - XS", ProductSizeDescription = "XS(Under 40kg)" },
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Clothes Male - S", ProductSizeDescription = "S(45 - 50kg)" },
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Clothes Male - M", ProductSizeDescription = "M(50 - 55kg)" },
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Clothes Male - L", ProductSizeDescription = "L(55 - 65kg)" },
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Clothes Male - XL", ProductSizeDescription = "XL(65 - 75kg)" },
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Clothes Male - XXL", ProductSizeDescription = "XXL(Over 75kg)" },

                // Clothes female sizes
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Clothes Female - XS", ProductSizeDescription = "XS(Under 40kg)" },
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Clothes Female - S", ProductSizeDescription = "S(45 - 50kg)" },
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Clothes Female - M", ProductSizeDescription = "M(50 - 55kg)" },
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Clothes Female - L", ProductSizeDescription = "L(55 - 60kg)" },
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Clothes Female - XL", ProductSizeDescription = "XL(60 - 70kg)" },
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Clothes Female - XXL", ProductSizeDescription = "XXL(Over 70kg)" }
            };

            context.ProductSizes.AddRange(clothes);
        }
    }
}
