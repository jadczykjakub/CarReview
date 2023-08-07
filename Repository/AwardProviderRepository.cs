using CarReview.Data;
using CarReview.Interfaces;
using CarReview.Models;

namespace CarReview.Repository
{


    public class AwardProviderRepository : IAwardProviderRepository
    {
        private readonly DataContext _context;

        public AwardProviderRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Award> GetAwardByAwardProvider(int id)
        {
            return _context.Awards.Where(a => a.AwardProvider.AwardProviderId == id).ToList();
        }

        public AwardProvider GetAwardProvider(int id)
        {
            return _context.AwardProviders.Where(ap => ap.AwardProviderId == id).FirstOrDefault();
        }

        public IEnumerable<AwardProvider> GetAwardProviders()
        {
            return _context.AwardProviders.ToList();
        }
    }
}
