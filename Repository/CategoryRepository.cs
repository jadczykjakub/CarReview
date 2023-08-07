using CarReview.Data;
using CarReview.Interfaces;
using CarReview.Models;

namespace CarReview.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }

        public bool CategoryExists(int id)
        {
            return _context.Categories.Any(c => c.CategoryId == id);
        }

        public ICollection<Car> GetCarByCategory(int id)
        {
            return _context.CarCategories.Where(c => c.CategoryId == id).Select(c => c.Car).ToList();
        }

        public ICollection<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategory(int id)
        {
            return _context.Categories.Where(c => c.CategoryId == id).FirstOrDefault();
        }
    }
}
