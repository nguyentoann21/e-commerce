using e_commerce_server.Models;

namespace e_commerce_server.DataAccess.OriginalData
{
    public class VolumeSizes
    {
        public static void VolumeSize(ApplicationDbContext context)
        {
            // Volume sizes
            var volumeSizes = new List<ProductSize>
            {
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Volume 5ml", ProductSizeDescription = "5ml" },
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Volume 10ml", ProductSizeDescription = "10ml" },
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Volume 30ml", ProductSizeDescription = "30ml" },
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Volume 100ml", ProductSizeDescription = "100ml" },
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Volume 330ml", ProductSizeDescription = "330ml" },
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Volume 360ml", ProductSizeDescription = "360ml" },
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Volume 500ml", ProductSizeDescription = "500ml" },
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Volume 1000ml", ProductSizeDescription = "1L" },
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Volume 1500ml", ProductSizeDescription = "1.5L" },
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Volume 2000ml", ProductSizeDescription = "2L" },
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Volume 3000ml", ProductSizeDescription = "3L" },
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Volume 5000ml", ProductSizeDescription = "5L" },
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Volume 10000ml", ProductSizeDescription = "10L" },
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Volume 30000ml", ProductSizeDescription = "30L" }
            };
            context.ProductSizes.AddRange(volumeSizes);
        }
    }
}
