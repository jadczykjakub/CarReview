namespace CarReview.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public ICollection<CarCategory> CarCategories { get; set; }
    }
}
