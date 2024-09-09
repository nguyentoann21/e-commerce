using System.ComponentModel.DataAnnotations;

namespace e_commerce_server.Models
{
    public class ProductSize
    {
        [Key]
        public Guid ProductSizeId { get; set; }
        [Required]
        public string ProductSizeName { get; set; } = string.Empty;
        public string ProductSizeDescription { get; set; } = string.Empty;
    }
}
