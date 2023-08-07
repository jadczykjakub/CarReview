namespace CarReview.Models
{
    public class Owner
    {
        public int OwnerId { get; set; }
        public string  Name { get; set; }

        public Country Country { get; set; }

        public ICollection<CarOwner> CarOwners { get; set; }
    }
}
