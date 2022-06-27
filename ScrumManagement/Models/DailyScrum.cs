namespace ScrumManagement.Models {
    public class DailyScrum {
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string Notes { get; set; } = "";
        public bool isHighlighted { get; set; } = false;
        public int SprintId { get; set; }
        public virtual Sprint? Sprint { get; set; }
    }
}
