using System.Text.Json.Serialization;

namespace ScrumManagement.Models {
    public class TeamList {
        public int Id { get; set; }
        public int TeamId { get; set; }

        [JsonIgnore]
        public Team? Team { get; set; }

        public int TeamMemberId { get; set; }
        
        public TeamMember? TeamMember { get; set; }
    }
}
