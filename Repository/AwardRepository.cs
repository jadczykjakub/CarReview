using CarReview.Data;
using CarReview.Interfaces;
using CarReview.Models;

namespace CarReview.Repository
{
    public class AwardRepository : IAwardRepository
    {

        private readonly DataContext _context;

        public AwardRepository(DataContext context)
        {
            _context = context;
        }

        public Award GetAward(int id)
        {
            return _context.Awards.Where(a => a.AwardId == id).FirstOrDefault();
        }

        public AwardProvider GetAwardProviderByAward(int id)
        {
            return _context.Awards.Where(a => a.AwardId == id).Select(a => a.AwardProvider).FirstOrDefault();
        }

        public IEnumerable<Award> GetAwards()
        {
            return _context.Awards.ToList();
        }
    }
}
