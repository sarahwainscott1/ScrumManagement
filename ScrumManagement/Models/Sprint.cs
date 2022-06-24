using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ScrumManagement.Models {
    public class Sprint {
        public int Id { get; set; }
        public int SprintLength { get; set; } = 14;
        public int MaxPoints { get; set; } = 112;
        public int TotalPoints { get; set; } = 0;
        public int RemainingPoints { get; set; } = 112;
        public int TotalTime { get; set; } = 0;
        [StringLength(30)]
        public string Status { get; set; } = "NEW";

        public int TeamId { get; set; } = 0;
        [JsonIgnore]
        public virtual Team? Team { get; set; }

        public virtual List<SprintList>? SprintLists { get; set; }
     

        public int ProductId { get; set; } = 0;
        
        public virtual Product? Product { get; set; }
        

    }
}
