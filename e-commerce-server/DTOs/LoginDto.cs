using System.ComponentModel.DataAnnotations;

namespace e_commerce_server.DTOs
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Username/EmailAddress is required")]
        public string UsernameOrEmail { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = string.Empty;

        public bool IsRemember { get; set; } = false;
    }
}
