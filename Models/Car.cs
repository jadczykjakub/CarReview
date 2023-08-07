namespace CarReview.Models
{
    public class Car
    {
        public int CarId { get; set; }
        public string Name { get; set; }

        public DateTime ProductionDate { get; set; }

        public ICollection<Award> Awards { get; set; }

        public ICollection<CarOwner> CarOwners { get; set; }

        public ICollection<CarCategory> CarCategories { get; set; }
    }
}
