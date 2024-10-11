using e_commerce_server.DTOs;
using e_commerce_server.Models;
using e_commerce_server.Repositories.Interfaces;
using e_commerce_server.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace e_commerce_server.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenService _jwtService;

        public AuthService(IUserRepository userRepository, IJwtTokenService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

        public async Task<string> LoginAsync(LoginDto loginDto)
        {
            var user = await _userRepository.GetUserByUsernameOrEmailAsync(loginDto.UsernameOrEmail);

            if(user == null)
            {
                throw new ApplicationException("Username or Email could not be found");
            }

            var passwordCheck = BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password);

            if (!passwordCheck)
            {
                throw new ApplicationException("Wrong password. Try again!");
            }

            var roles = await _userRepository.GetUserRolesAsync(user);

            if (roles == null || roles.Count == 0)
            {
                throw new ApplicationException("User has no roles assigned");
            }

            var token = _jwtService.GenerateToken(user, roles);
            //var refreshToken = _jwtService.RefreshToken();

            return token;
        }
    }
}
