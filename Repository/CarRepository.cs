using CarReview.Data;
using CarReview.Interfaces;
using CarReview.Models;

namespace CarReview.Repository
{
    public class CarRepository : ICarRepository
    {
        private readonly DataContext _context;

        public CarRepository(DataContext context)
        {
            _context = context;
        }

        public bool CarExists(int id)
        {
            return _context.Cars.Any(c => c.CarId == id);
        }

        public Car GetCar(int id)
        {
            return _context.Cars.Where(c => c.CarId == id).FirstOrDefault();
        }

        public Car GetCar(string name)
        {
            return _context.Cars.Where(c => c.Name == name).FirstOrDefault();
        }

        public ICollection<Car> GetCars()
        {
            return _context.Cars.OrderBy(c => c.CarId).ToList();
        }
    }
}
