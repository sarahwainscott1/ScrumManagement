using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ScrumManagement.Models {
    public class TeamMember {
        public int Id { get; set; }
        [StringLength(80)]
        public string Name { get; set; } = string.Empty;
        [StringLength(80)]
        public string Email { get; set; } = string.Empty;
        [StringLength(80)]
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = "Developer";

        public virtual List<StrengthList>? StrengthList { get; set; }
        
        [JsonIgnore]
        public virtual List<Story>? Story { get; set; }
        public virtual List<Coach>? Coach { get; set; }
        
 
    }
}
