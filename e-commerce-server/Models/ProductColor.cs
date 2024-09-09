using System.ComponentModel.DataAnnotations;

namespace e_commerce_server.Models
{
    public class ProductColor
    {
        [Key]
        public Guid ProductColorId { get; set; }
        [Required]
        public string ProductColorName { get; set; } = string.Empty;
        public string ProductColorDescription { get; set; } = string.Empty;
    }
}
