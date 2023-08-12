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

        public bool CreateAward(Award award)
        {
            _context.Awards.Add(award);
            return Save();
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();

            return saved > 0 ? true : false;
        }

        public bool UpdateAward(Award award)
        {
            _context.Awards.Update(award);

            return Save();
        }

        public bool AwardExists(int id)
        {
            return _context.Awards.Any(a => a.AwardId == id);
        }

        public bool DeleteAward(Award award)
        {
            _context.Awards.Remove(award);

            return Save();
        }
    }
}
