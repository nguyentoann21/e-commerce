using System.ComponentModel.DataAnnotations;

namespace e_commerce_server.DTOs
{
    public class RegisterDto
    {
        private string _gender = "male";

        [Required(ErrorMessage = "Username is required")]
        [MinLength(5, ErrorMessage = "Username must be at least 5 characters long")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
        [MaxLength(32, ErrorMessage = "Password can be up to 32 characters long")]
        public string Password { get; set; } = string.Empty;

        public IFormFile? Avatar { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string EmailAddress { get; set; } = string.Empty;

        [Phone(ErrorMessage = "Invalid phone number format")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "Gender is required")]
        [RegularExpression("male|female|hidden", ErrorMessage = "Gender must be either male, female, or hidden")]
        public string Gender { 
            get => _gender; 
            set => _gender = value.ToLower(); 
        }
    }
}
