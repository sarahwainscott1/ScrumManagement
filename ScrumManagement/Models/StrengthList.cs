using System.Text.Json.Serialization;

namespace ScrumManagement.Models {
    public class StrengthList {
        public int Id { get; set; }
        public int TeamMemberId { get; set; }
        [JsonIgnore]
        public virtual TeamMember? TeamMember { get; set; }
        public int StrengthId { get; set; }
        public virtual Strength? Strength { get; set; }
    }
}
