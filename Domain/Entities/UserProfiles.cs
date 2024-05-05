using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class UserProfiles
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }

        [JsonIgnore]
        public User User { get; set; } = default!;
        public string UserRank { get; set; } = "User";
        public string? AvatarUrl { get; set; }
    }
}