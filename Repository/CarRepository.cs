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

        public bool CreateCar(int ownerId, int categoryId, Car car)
        {
            var carOwnerEntity = _context.Owners.Where(o => o.OwnerId == ownerId).FirstOrDefault();
            var category = _context.Categories.Where(c => c.CategoryId == categoryId).FirstOrDefault();

            var carOwner = new CarOwner()
            {
                Owner = carOwnerEntity,
                Car = car,
            };

            _context.Add(carOwner);

            var carCategory = new CarCategory()
            {
                Category = category,
                Car = car,
            };

            _context.Add(carCategory);
            _context.Add(car);

            return Save();
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

        public bool Save()
        {
            var saved = _context.SaveChanges();

            return saved > 0 ? true : false;
        }

        public bool UpdateCar(Car car)
        {
            _context.Update(car);
            return Save();
        }

        public bool DeleteCar(Car car)
        {
            _context.Remove(car);
            return Save();
        }
    }
}
