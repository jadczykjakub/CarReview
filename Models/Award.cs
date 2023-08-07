namespace CarReview.Models
{
    public class Award
    {
        public int AwardId { get; set; }
        public string Title { get; set; }
        public AwardProvider AwardProvider { get; set; }
        public Car Car { get; set; }
    }
}
