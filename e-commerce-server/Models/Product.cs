using System.ComponentModel.DataAnnotations;

namespace e_commerce_server.Models
{
    public class Product
    {
        [Key]
        public Guid ProductId { get; set; }
        [Required]
        public string ProductName { get; set; } = string.Empty;
        public string ProductDescription { get; set; } = string.Empty;
        public string ProductImage { get; set; } = string.Empty;
        [Required]
        [Display(Name = "ProductPrice")]
        [Range(0.01, double.MaxValue)]
        [DisplayFormat(DataFormatString = "{0:0.00}$")]
        public decimal ProductPrice { get; set; }
        public int ProductQuantity { get; set; } = 0;
        [Required]
        [Display(Name = "ProductDiscount")]
        [Range(0, 100)]
        [DisplayFormat(DataFormatString = "{0:0}%")]
        public int ProductDiscount { get; set; } = 0;
        public int ProductRate { get; set; } = 0;
        public DateTime CreatedAt { get; set; }
        public Category? Categories { get; set; }
        public List<ProductColor> ProductColors { get; set; } = new List<ProductColor>();
        public List<ProductSize> ProductSizes { get; set; } = new List<ProductSize>();
    }
}
