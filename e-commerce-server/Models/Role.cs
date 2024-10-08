﻿using System.ComponentModel.DataAnnotations;

namespace e_commerce_server.Models
{
    public class Role
    {
        [Key]
        public Guid RoleId { get; set; }
        [Required]
        public string RoleName { get; set; } = string.Empty;
        public string RoleDescription { get; set; } = string.Empty;
        public ICollection<UserRole> UserRoles { get; set; } = new HashSet<UserRole>();
    }
}
