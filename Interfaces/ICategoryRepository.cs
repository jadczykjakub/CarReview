using CarReview.Models;

namespace CarReview.Interfaces
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();
        Category GetCategory(int id);
        ICollection<Car> GetCarByCategory(int id);
        bool CategoryExists(int id);
    }
}
