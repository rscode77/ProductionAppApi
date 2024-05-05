using Domain.Entities;

namespace ApplicationUser.User
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; } = default!;
        public string Email { get; set; } = default!;
        public DateTime CreationDate { get; set; }
        public bool UserConfirmed { get; set; }
        public bool IsOnline { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; } = default!;
        public UserProfiles UserProfiles { get; set; } = default!;
    }
}