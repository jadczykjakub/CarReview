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

        public bool CreateAwardProvider(AwardProvider awardProvider)
        {
            _context.AwardProviders.Add(awardProvider);

            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();

            return saved > 0 ? true : false;
        }

        public bool UpdateAwardProvider(AwardProvider awardProvider)
        {
            _context.AwardProviders.Update(awardProvider);
            return Save();
        }

        public bool AwardProviderExist(int id)
        {
            return _context.AwardProviders.Any(ap => ap.AwardProviderId == id);
        }

        public bool DeleteAwardProvider(AwardProvider awardProvider)
        {
            _context.AwardProviders.Remove(awardProvider);

            return Save();
        }
    }
}
