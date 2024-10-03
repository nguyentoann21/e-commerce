using e_commerce_server.Models;

namespace e_commerce_server.DataAccess.OriginalData
{
    public class SeedCarEngineSizes
    {
        public static void SeedCarEngineSize(ApplicationDbContext context)
        {
            // Engine displacement car volume sizes 
            var engines = new List<ProductSize>
            {
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Car 1000cc", ProductSizeDescription = "1000cc" },
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Car 1200cc", ProductSizeDescription = "1200cc" },
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Car 1300cc", ProductSizeDescription = "1300cc" },
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Car 1400cc", ProductSizeDescription = "1400cc" },
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Car 1600cc", ProductSizeDescription = "1600cc" },
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Car 1800cc", ProductSizeDescription = "1800cc" },
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Car 2000cc", ProductSizeDescription = "2000cc" },
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Car 2200cc", ProductSizeDescription = "2200cc" },
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Car 2500cc", ProductSizeDescription = "2500cc" },
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Car 3000cc", ProductSizeDescription = "3000cc" },
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Car 3500cc", ProductSizeDescription = "3500cc" },
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Car 4000cc", ProductSizeDescription = "4000cc" },
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Car 5000cc", ProductSizeDescription = "5000cc" },
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Car 6000cc", ProductSizeDescription = "6000cc" },
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Car 7000cc", ProductSizeDescription = "7000cc" },
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Car 8000cc", ProductSizeDescription = "8000cc" }
            };
            context.ProductSizes.AddRange(engines);
        }
    }
}
