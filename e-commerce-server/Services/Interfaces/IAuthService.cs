using e_commerce_server.DTOs;

namespace e_commerce_server.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> LoginAsync(LoginDto loginDto);
    }
}
