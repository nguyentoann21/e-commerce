using e_commerce_server.Models;

namespace e_commerce_server.DataAccess.OriginalData
{
    public class SeedMotorbikeEngineSizes
    {
        public static void SeedMotorbikeEngineSize(ApplicationDbContext context)
        {
            // Engine displacement motobike volume sizes 
            var engines = new List<ProductSize> 
            {
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Motorbike 50cc", ProductSizeDescription = "50cc" },
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Motorbike 70cc", ProductSizeDescription = "70cc" },
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Motorbike 80cc", ProductSizeDescription = "80cc" },
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Motorbike 100cc", ProductSizeDescription = "100cc" },
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Motorbike 110cc", ProductSizeDescription = "110cc" },
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Motorbike 125cc", ProductSizeDescription = "125cc" },
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Motorbike 140cc", ProductSizeDescription = "140cc" },
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Motorbike 150cc", ProductSizeDescription = "150cc" },
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Motorbike 160cc", ProductSizeDescription = "160cc" },
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Motorbike 180cc", ProductSizeDescription = "180cc" },
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Motorbike 200cc", ProductSizeDescription = "200cc" },
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Motorbike 220cc", ProductSizeDescription = "220cc" },
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Motorbike 250cc", ProductSizeDescription = "250cc" },
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Motorbike 300cc", ProductSizeDescription = "300cc" },
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Motorbike 350cc", ProductSizeDescription = "350cc" },
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Motorbike 400cc", ProductSizeDescription = "400cc" },
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Motorbike 500cc", ProductSizeDescription = "500cc" },
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Motorbike 600cc", ProductSizeDescription = "600cc" },
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Motorbike 750cc", ProductSizeDescription = "750cc" },
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Motorbike 1000cc", ProductSizeDescription = "1000cc" },
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Motorbike 1200cc", ProductSizeDescription = "1200cc" },
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Motorbike Over 1200cc", ProductSizeDescription = "Over 1200cc" }
            };
            context.ProductSizes.AddRange(engines);
        }
    }
}
