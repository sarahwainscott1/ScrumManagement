using System.Text.Json.Serialization;

namespace ScrumManagement.Models {
    public class Sprint {
        public int Id { get; set; }
        public int SprintLength { get; set; } = 14;
        public int MaxPoints { get; set; } = 112;
        public int TotalPoints { get; set; } = 0;
        public int RemainingPoints { get; set; } = 112;
        public int TotalTime { get; set; } = 0;
   
        public virtual List<Story>? Story { get; set; }
    }
}
