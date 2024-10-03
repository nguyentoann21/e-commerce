namespace e_commerce_server.Models
{
    public class UserRole
    {
        public Guid UserId { get; set; }
        // Null is a "non-null" type
        public User User { get; set; } = null!;
        public Guid RoleId { get; set; }
        // Null is a "non-null" type
        public Role Role { get; set; } = null!;
    }
}
