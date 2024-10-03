using e_commerce_server.DTOs;
using e_commerce_server.Models;

namespace e_commerce_server.Services.Interfaces
{
    public interface IAccountService
    {
        Task AssignRole(User user, List<string> roles);
        bool IsStrongPassword(string password);
        bool IsStrongUsername(string username);
        Task<string> LoginAsync(LoginDto loginDto);
        Task<UserDto> RegisterAsync(RegisterDto registerDto, List<string> roles);
        Task<UserDto> RegisterUserAsync(RegisterDto registerDto);
        Task<bool> UserHasRole(User user, string role);
        Task<bool> UserHasAnyRole(User user, List<string> roles);
    }
}
