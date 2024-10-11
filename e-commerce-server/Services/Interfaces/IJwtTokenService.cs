using e_commerce_server.Models;

namespace e_commerce_server.Services.Interfaces
{
    public interface IJwtTokenService
    {
        string GenerateToken(User user, IList<string> roles);
        string RefreshToken();
    }
}
