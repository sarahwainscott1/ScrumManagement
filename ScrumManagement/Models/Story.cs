using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ScrumManagement.Models {
    public class Story {
        public int Id { get; set; }
        [StringLength(30)]
        public string User { get; set; } = string.Empty;
        [StringLength(100)]
        public string Feature { get; set; } = string.Empty;
        [StringLength(100)]
        public string Value { get; set; } = string.Empty;
        [StringLength(30)]
        public string Importance { get; set; } = string.Empty;
        public int EstimatedPoints { get; set; }
        public int ActualTime { get; set; } = 0;

        public int ProductId { get; set; }
        
        public virtual Product? Product { get; set; }
        
    }
}
