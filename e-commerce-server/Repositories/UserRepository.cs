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

        public async Task AssignRole(User user, string role)
        {
            // Check if the role exists in DB or not
            var existRole = await _context.Roles.FirstOrDefaultAsync(r => r.RoleName == role);
            if(existRole == null)
            {
                throw new ApplicationException("Role could not be found");
            }

            // Check if the if the user's role exists in DB or not
            var existUser = await _context.Users.Include(u => u.UserRoles).FirstOrDefaultAsync(u => u.UserId == user.UserId);
            if(existUser == null)
            {
                throw new ApplicationException("User could not be found");
            }

            // Remove existing role—mean remove role user enter and replace it by role in db table
            if (existUser.UserRoles != null && existUser.UserRoles.Any())
            {
                _context.UserRoles.RemoveRange(existUser.UserRoles);
            }

            /**
             * Set UserId and RoleId for table UserRoles when registering a new account
             * The roleId will get data from table Roles 
             **/
            var userRole = new UserRole
            {
                UserId = user.UserId,
                RoleId = existRole.RoleId
            };

            // Add data to the table and save it
            _context.UserRoles.Add(userRole);
            await _context.SaveChangesAsync();
        }

        // Method to save avatars
        private async Task<string> AvatarStorageAsync(IFormFile avatar)
        {
            // If users do not enter avatar data, the system will set the user avatar as the default avatar
            if (avatar == null) return "default-avatar.png";

            // Generate unique file name limit duplicate file name
            string uniqueFileName = Guid.NewGuid().ToString() + "_" +avatar.FileName;
            // Setup folder to storage avatar files
            var storageFolder = Path.Combine("wwwroot", "avatars");
            Directory.CreateDirectory(storageFolder);

            var avatarFilePath = Path.Combine(storageFolder, uniqueFileName);
            using (var fileStream = new FileStream(avatarFilePath, FileMode.Create))
            {
                await avatar.CopyToAsync(fileStream);
            }

            // Return the correct file name and not insert anything before the file name
            return Path.Combine(string.Empty, uniqueFileName);
        }

        // Method to check user existing or not
        private async Task<User> FindUserByIdAsync(Guid userId)
        {
            // Check user existing or not
            var existingUser = await _context.Users.FindAsync(userId);

            // If a user does not exist, throw an exception
            if (existingUser == null) throw new ApplicationException("User could not be found");
            
            // Return user if found
            return existingUser;
        }

        public async Task<string> GetUserRoleAsync(Guid userId)
        {
            // Get user by Id with take relation data from 2 tables are UserRole and Role
            var user = await _context.Users.Include(u => u.UserRoles).ThenInclude(ur => ur.Role).FirstOrDefaultAsync(u => u.UserId == userId);

            // If user is null or UserRoles is null or user have a different role out of data table UserRole, throw an exception
            if (user == null || user.UserRoles == null || !user.UserRoles.Any()) throw new ApplicationException("User's role could not be found");

            // Get a user's role name if it does not exist, that return null and not error occur 
            var role = user?.UserRoles.FirstOrDefault()?.Role?.RoleName;

            // If role is null-means the user's role name is null, throw an exception
            if (role == null) throw new ApplicationException("User's role could not be found");

            // Return user's role name if found
            return role;
        }

        // Method to register a new account with role
        public async Task<UserDto> RegisterAsync(RegisterDto registerDto, string role)
        {
            role = "User";

            // Get the user if the Username/EmailAddress input and data in db are the same
            var user = await _context.Users.AnyAsync(u => u.Username == registerDto.Username || u.EmailAddress == registerDto.EmailAddress);

            // Check if user is not null-means Username/EmailAddress is already in db
            if (user) throw new ApplicationException("Username/EmailAddress already exists. Try again!");

            // Save avatar data if user upload or save default avatar if user does not input
            var avatarUrl = registerDto.Avatar != null ? await AvatarStorageAsync(registerDto.Avatar) : "default-avatar.png";

            // Take data from user form sent
            var registerUser = new User
            {
                UserId = Guid.NewGuid(),
                Username = registerDto.Username,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                // Using BCrypt to hash password before saving to db
                Password = BCrypt.Net.BCrypt.HashPassword(registerDto.Password),
                AvatarUrl = avatarUrl,
                EmailAddress = registerDto.EmailAddress,
                PhoneNumber = registerDto.PhoneNumber,
                Address = registerDto.Address,
                Gender = registerDto.Gender
            };

            // Insert new user to db and save it
            _context.Users.Add(registerUser);
            await _context.SaveChangesAsync();

            // Assign role after saving user
            await AssignRole(registerUser, role);

            // Return the data the user just added to the db
            return new UserDto
            {
                UserId = registerUser.UserId,
                Username = registerUser.Username,
                FirstName = registerUser.FirstName,
                LastName = registerUser.LastName,
                AvatarUrl = avatarUrl,
                EmailAddress = registerUser.EmailAddress,
                PhoneNumber = registerUser.PhoneNumber,
                Address = registerUser.Address,
                Gender = registerUser.Gender
            };
        }

        // Method to register only a new user account
        public Task<UserDto> RegisterUserAsync(RegisterDto registerDto)
        {
            return RegisterAsync(registerDto, "User");
        }
    }
}
