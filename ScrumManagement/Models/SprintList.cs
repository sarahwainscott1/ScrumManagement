using System.Text.Json.Serialization;

namespace ScrumManagement.Models {
    public class SprintList {
        public int Id { get; set; }

        public int SprintId { get; set; }
        [JsonIgnore]
        public virtual Sprint? Sprint { get; set; }

        public int StoryId { get; set; } = 0;
        public virtual Story? Story { get; set; }

    }
}
