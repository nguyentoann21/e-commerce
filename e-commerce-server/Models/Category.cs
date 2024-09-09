using System.ComponentModel.DataAnnotations;

namespace e_commerce_server.Models
{
    public class Category
    {
        [Key]
        public Guid CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; } = string.Empty;
        public string CategoryDescription { get; set; } = string.Empty;
        public string CategoryImage { get; set; } = string.Empty;
        public ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}
