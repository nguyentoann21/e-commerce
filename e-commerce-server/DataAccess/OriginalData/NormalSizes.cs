using e_commerce_server.Models;

namespace e_commerce_server.DataAccess.OriginalData
{
    public class NormalSizes
    {
        public static void NormalSize(ApplicationDbContext context)
        {
            // Normal sizes
            var normals = new List<ProductSize> 
            {
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Normal Small", ProductSizeDescription = "Small" },
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Normal Medium", ProductSizeDescription = "Medium" },
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Normal Large", ProductSizeDescription = "Large" },
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Normal Single", ProductSizeDescription = "Single" },
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "Normal Double", ProductSizeDescription = "Double" }
            };
            context.ProductSizes.AddRange(normals);
        }
    }
}
