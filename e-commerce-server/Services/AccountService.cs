using e_commerce_server.DataAccess;
using e_commerce_server.DTOs;
using e_commerce_server.Models;
using e_commerce_server.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace e_commerce_server.Services
{
    public class AccountService : IAccountService
    {
        private readonly ApplicationDbContext _context;
        private readonly IStorage _storage;

        public AccountService(ApplicationDbContext context, IStorage storage)
        {
            _context = context;
            _storage = storage;
        }

        public async Task AssignRole(User user, List<string> roles)
        {
            // Iterate through each role in the provided list of roles
            foreach (var role in roles)
            {
                // Retrieve the role from the database based on the role name
                var roleName = await _context.Roles.FirstOrDefaultAsync(r => r.RoleName == role);

                // Check if the role does not exist in the database
                if (roleName == null)
                {
                    // Throw an exception if the role does not exist
                    throw new ApplicationException($"Role '{role}' does not exist");
                }

                // Check if the user already has the specified role
                var userExistRole = await _context.UserRoles.AnyAsync(ur => ur.UserId == user.UserId && ur.RoleId == roleName.RoleId);

                // If the user does not have the role, add it to the UserRoles table
                if (!userExistRole)
                {
                    _context.UserRoles.Add(new UserRole
                    {
                        // Set the UserId for the new UserRole
                        UserId = user.UserId,
                        // Set the RoleId for the new UserRole
                        RoleId = roleName.RoleId,
                    });
                }
            }

            // Save all changes made to the UserRoles in the database
            await _context.SaveChangesAsync();
        }

        public bool IsStrongPassword(string password)
        {
            // Check the password length
            if (password.Length < 8 || password.Length > 32) return false;

            /*** Check character types ***/
            // Contains uppercase characters
            bool hasUpperChar = password.Any(char.IsUpper);
            // Contains lowercase characters
            bool hasLowerChar = password.Any(char.IsLower);
            // Contains number
            bool hasNumber = password.Any(char.IsDigit);
            // Contains special characters - check it is not a letter or digit
            bool hasSpecialChar = password.Any(ch => !char.IsLetterOrDigit(ch));
            // Returns true for passwords that meet all conditions
            return hasUpperChar && hasLowerChar && hasNumber && hasSpecialChar;
        }

        public bool IsStrongUsername(string username)
        {
            // Check the username length
            if (username.Length < 6 || username.Length > 20) return false;

            // Check the username include space
            if (username.Contains(" ")) return false;

            /*** Check character types ***/
            // Contains letter
            bool hasLetter = username.Any(char.IsLetter);
            // Contains number
            bool hasNumber = username.Any(char.IsDigit);
            // Contains special characters ( # or $ or & or _ or . )
            bool hasSpecialChar = username.Any(ch => "#$&_.".Contains(ch));
            // Returns true for passwords that meet all conditions
            return hasLetter && hasNumber && hasSpecialChar;
        }

        public Task<string> LoginAsync(LoginDto loginDto)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDto> RegisterAsync(RegisterDto registerDto, List<string> roles)
        {
            // Begin a new database transaction
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                // Check if a user with the same username already exists
                var usernameExist = await _context.Users.AnyAsync(u => u.Username == registerDto.Username);

                // Check if a user with the same email address already exists
                var emailExist = await _context.Users.AnyAsync(u => u.EmailAddress == registerDto.EmailAddress);

                // If both username and email already exist, throw an exception
                if (usernameExist && emailExist)
                {
                    throw new ApplicationException("Username and EmailAddress already exists in another account");
                }

                // If either username or email exists, throw an exception with the corresponding message
                if (usernameExist || emailExist)
                {
                    throw new ApplicationException(usernameExist? "Username already exists in another account" : "EmailAddress already exists in another account");
                }

                // Upload the avatar image and get the URL - use a default image if no avatar is provided
                var avatar = registerDto.Avatar != null ? await _storage.StaticFileStorage(registerDto.Avatar, "avt") : "default-image-file";

                // Check if the provided username meets the strength criteria
                var checkUsername = IsStrongUsername(registerDto.Username);

                // If the password is not strong enough, throw an exception
                if (!checkUsername)
                {
                    throw new ApplicationException("Usernames must be 6-20 characters long, contain letters, numbers, special characters, and no spaces");
                }

                // Check if the provided password meets the strength criteria
                var checkPassword = IsStrongPassword(registerDto.Password);

                // If the password is not strong enough, throw an exception
                if (!checkPassword)
                {
                    throw new ApplicationException("Password is 8-32 characters long, including uppercase and lowercase letters, numbers and special characters");
                }

                // Create a new User object with the provided registration details
                var registerUser = new User
                {
                    // Generate a new unique user ID
                    UserId = Guid.NewGuid(),
                    Username = registerDto.Username,
                    FirstName = registerDto.FirstName,
                    LastName = registerDto.LastName,
                    // Hash the password for secure storage
                    Password = BCrypt.Net.BCrypt.HashPassword(registerDto.Password),
                    AvatarUrl = avatar,
                    EmailAddress = registerDto.EmailAddress,
                    PhoneNumber = registerDto.PhoneNumber,
                    Address = registerDto.Address,
                    Gender = registerDto.Gender.ToLower()
                };

                // Add the new user to the database context
                _context.Users.Add(registerUser);

                // Save changes to the database
                await _context.SaveChangesAsync();

                // Assign roles to the newly created user
                await AssignRole(registerUser, roles);

                // Commit the transaction if all operations are successful
                await transaction.CommitAsync();

                // Return a UserDto object containing the newly registered user's information
                return new UserDto
                {
                    UserId = registerUser.UserId,
                    Username = registerUser.Username,
                    FirstName = registerUser.FirstName,
                    LastName = registerUser.LastName,
                    AvatarUrl = avatar,
                    EmailAddress = registerUser.EmailAddress,
                    PhoneNumber = registerUser.PhoneNumber,
                    Address = registerUser.Address,
                    Gender = registerUser.Gender
                };
            }
            catch (Exception ex) 
            {
                // Rollback the transaction in case of an error
                await transaction.RollbackAsync();
                // Throw an exception indicating that registration failed
                throw new ApplicationException("Register failed " + ex);
            }
        }

        public Task<UserDto> RegisterUserAsync(RegisterDto registerDto)
        {
            // Create a list containing the default role "User" for the new user
            var role = new List<string> { "User" };

            // Call the RegisterAsync method with the provided registration data and the user role
            return RegisterAsync(registerDto, role);
        }

        public async Task<bool> UserHasAnyRole(User user, List<string> roles)
        {
            /* ***
             * 
             * Query the UserRoles table to check if the user has any of the specified roles 
             * Filter UserRoles to only include those for the specified user
             * Check if any of the user's roles match the roles provided in the list
             * 
             * ***/
            return await _context.UserRoles.Where(ur => ur.UserId == user.UserId).AnyAsync(ur => roles.Contains(ur.Role.RoleName));
        }

        public async Task<bool> UserHasRole(User user, string role)
        {
            /* ***
             * 
             * Check if the specified user has the given role in the UserRoles table
             * Use AnyAsync to determine if there are any entries matching the user ID and role name
             * 
             * ***/
            return await _context.UserRoles.AnyAsync(ur => ur.UserId == user.UserId && ur.Role.RoleName == role);
        }
    }
}
