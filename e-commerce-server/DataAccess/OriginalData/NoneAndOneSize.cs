using e_commerce_server.Models;

namespace e_commerce_server.DataAccess.OriginalData
{
    public class NoneAndOneSize
    {
        public static void NaOSize(ApplicationDbContext context)
        {
            var naos = new List<ProductSize> {
                // N/A sizes
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "N/A", ProductSizeDescription = "Sizes vary by product type" },

                // One size
                new ProductSize { ProductSizeId = Guid.NewGuid(), ProductSizeName = "One Size", ProductSizeDescription = "One size fits all for most products" }
            };
            context.ProductSizes.AddRange(naos);
        }
    }
}
