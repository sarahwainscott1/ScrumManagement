using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ScrumManagement.Models {
    public class Team {
        public int Id { get; set; }
        [StringLength(30)]
        public string Name { get; set; } = "";

        public List<TeamList>? TeamList { get; set; }
        public List<Sprint>? Sprints { get; set; }

        public int ProductId { get; set; } = 0;
        
        public virtual Product? Product { get; set; }

    }
}
