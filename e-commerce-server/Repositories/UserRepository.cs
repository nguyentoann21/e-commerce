using e_commerce_server.DataAccess;
using e_commerce_server.DTOs;
using e_commerce_server.Models;
using e_commerce_server.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace e_commerce_server.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByUsernameOrEmailAsync(string usernameOrEmail)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == usernameOrEmail || u.EmailAddress == usernameOrEmail);

            if(user == null)
            {
                throw new ApplicationException("Username or Email could not be found");
            }
            return user;
        }

        public async Task<List<string>> GetUserRolesAsync(User user)
        {
            var roles = await _context.UserRoles.Where(ur => ur.UserId == user.UserId).Include(ur => ur.Role).Select(ur => ur.Role.RoleName).ToListAsync();
            return roles;
        }
    }
}
