using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ScrumManagement.Models {
    public class Coach {
        public int Id { get; set; }
        public int TeamMemberId { get; set; }
        [JsonIgnore]
        public virtual TeamMember? TeamMember { get; set; }
        [StringLength(200)]
        public string Reason { get; set; } = "";
        [StringLength(200)]
        public string Outcome { get; set; } = "";
    }
}
