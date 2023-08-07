using CarReview.Data;
using CarReview.Interfaces;
using CarReview.Models;

namespace CarReview.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly DataContext _context;

        public OwnerRepository(DataContext context)
        {
            _context = context;
        }
    
        public ICollection<Car> GetCarByOwner(int ownerId)
        {
            return _context.CarOwners.Where(c => c.Owner.OwnerId == ownerId).Select(c => c.Car).ToList();
        }

        public Owner GetOwner(int ownerId)
        {
            return _context.Owners.Where(o => o.OwnerId == ownerId).FirstOrDefault();
        }


        public ICollection<Owner> GetOwners()
        {
            return _context.Owners.ToList();
        }

        public bool OwnerExist(int ownerId)
        {
            return _context.Owners.Any(c => c.OwnerId == ownerId);
        }
    }
}
