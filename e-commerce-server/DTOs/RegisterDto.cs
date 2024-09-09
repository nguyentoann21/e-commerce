using System.ComponentModel.DataAnnotations;

namespace e_commerce_server.DTOs
{
    public class RegisterDto
    {
        public string Username { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public IFormFile? Avatar { get; set; }
        [EmailAddress]
        public string EmailAddress { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Gender { get; set; } = "Male";
        public string RoleName { get; set; } = string.Empty;
    }
}
