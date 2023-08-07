using CarReview.Models;

namespace CarReview.Interfaces
{
    public interface IOwnerRepository
    {
        ICollection<Owner> GetOwners();
        Owner GetOwner(int ownerId);
        ICollection<Car> GetCarByOwner(int ownerId);

        bool OwnerExist(int ownerId);
    }
}
