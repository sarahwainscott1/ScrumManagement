using System.ComponentModel.DataAnnotations;

namespace ScrumManagement.Models {
    public class Team {
        public int Id { get; set; }
        [StringLength(30)]
        public string Name { get; set; } = "";
        public List<TeamList>? TeamList { get; set; }

    }
}
