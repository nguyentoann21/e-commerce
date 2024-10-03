using e_commerce_server.Models;

namespace e_commerce_server.DataAccess.OriginalData
{
    public class SeedRoles
    {
        public static void SeedRole(ApplicationDbContext context)
        {
            // Seed roles
            var roles = new List<Role> {
                new Role { RoleId = Guid.NewGuid(), RoleName = "User", RoleDescription = "User is a role for the customer in the system" },
                new Role { RoleId = Guid.NewGuid(), RoleName = "Admin", RoleDescription = "Admin is the role of the admin/manager in the system" },
                new Role { RoleId = Guid.NewGuid(), RoleName = "Employee", RoleDescription = "Employee is a role for the staff in the system" }
            };
            context.Roles.AddRange(roles);
        }
    }
}
