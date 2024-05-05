using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class UserActivity
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }

        [JsonIgnore]
        public User? User { get; set; }
        public DateTime LastActivity { get; set; } = DateTime.UtcNow;
        public bool IsBanned { get; set; } = false;
        public string? BanReason { get; set; }
    }
}