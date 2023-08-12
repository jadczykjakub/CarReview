using CarReview.Models;

namespace CarReview.Interfaces
{
    public interface ICarRepository
    {
        ICollection<Car> GetCars();
        Car GetCar(int id);
        Car GetCar(string name);
        bool CarExists(int id);
        bool CreateCar(int ownerId, int categoryId, Car car);
        bool UpdateCar( Car car);
        bool DeleteCar(Car car);
        bool Save();
    }
}
