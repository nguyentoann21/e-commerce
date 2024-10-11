using e_commerce_server.DTOs;
using e_commerce_server.Models;

namespace e_commerce_server.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByUsernameOrEmailAsync(string usernameOrEmail);
        Task<List<string>> GetUserRolesAsync(User user); 
    }
}
