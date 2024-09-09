using e_commerce_server.DTOs;
using e_commerce_server.Models;

namespace e_commerce_server.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<UserDto> RegisterAsync(RegisterDto registerDto, string role);
        Task<UserDto> RegisterUserAsync(RegisterDto registerDto);
        Task AssignRole(User user, string role);
        Task<string> GetUserRoleAsync(Guid userId);
    }
}
