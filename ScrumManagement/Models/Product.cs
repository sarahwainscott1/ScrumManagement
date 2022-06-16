namespace ScrumManagement.Models {
    public class Product {
        public int Id { get; set; }
        public int StoryId { get; set; }
        public virtual List<Story>? Story { get; set; }
        public int SprintId { get; set; }
        public virtual List<Sprint>? Sprint { get; set; }
    }
}
