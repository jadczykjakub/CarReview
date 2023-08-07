namespace CarReview.Models
{
    public class AwardProvider
    {
        public int AwardProviderId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<Award> Awards { get; set; }
    }
}
