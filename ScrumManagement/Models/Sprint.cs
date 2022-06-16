namespace ScrumManagement.Models {
    public class Sprint {
        public int Id { get; set; }
        public int SprintLength { get; set; } = 14;
        public int TotalPoints { get; set; } = 0;
        public int TotalTime { get; set; } = 0;
        public int StoryId { get; set; }
        public virtual List<Story>? Story { get; set; }
    }
}
