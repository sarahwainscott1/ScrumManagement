namespace ScrumManagement.Models {
    public class DailyScrum {
        public int Id { get; set; }
        public DateTime Date { get; set; } = new DateTime();
        public string Notes { get; set; } = "";
        public bool isHighlighted = false;
    }
}
