using e_commerce_server.Models;

namespace e_commerce_server.DataAccess.OriginalData
{
    public class SeedElectricEngineSizes
    {
        public static void SeedElectricEngineSize(ApplicationDbContext context) 
        {
            // Engine displacement electric volume sizes 
            var engines = new List<ProductSize>
            {
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Electric 0.5 - 1 kW", ProductSizeDescription = "0.5 - 1 kW" },
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Electric 0.5 - 1.5kW", ProductSizeDescription = "0.5 - 1.5kW" },
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Electric 1 - 2 kW", ProductSizeDescription = "1 - 2 kW" },
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Electric 2 - 4 kW", ProductSizeDescription = "2 - 4 kW" },
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Electric 3 - 5 kW", ProductSizeDescription = "3 - 5 kW" },
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Electric 5 - 10 kW", ProductSizeDescription = "5 - 10 kW" },
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Electric 50 - 150 kW", ProductSizeDescription = "50 - 150 kW" },
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Electric 150 - 250 kW", ProductSizeDescription = "150 - 250 kW" },
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Electric 150 - 300 kW", ProductSizeDescription = "150 - 300 kW" },
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Electric 200 - 400 kW", ProductSizeDescription = "200 - 400 kW" }
            };
            context.ProductSizes.AddRange(engines);
        }
    }
}
