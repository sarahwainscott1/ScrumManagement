using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ScrumManagement.Models {
    public class Product {
        public int Id { get; set; }
        [StringLength(30)]
        public string Name { get; set; } = "";
        public int TeamMemberId { get; set; }
        
        public virtual TeamMember? TeamMember { get; set; }
        
        public virtual List<Story>? Stories { get; set; }
        
        public virtual List<Sprint>? Sprints { get; set; }
        
        public virtual List<Team>? Teams { get; set; }
       
    }
}
