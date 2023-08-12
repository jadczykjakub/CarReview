using CarReview.Models;

namespace CarReview.Interfaces
{
    public interface IAwardRepository
    {
        IEnumerable<Award> GetAwards();
        Award GetAward(int id);
        AwardProvider GetAwardProviderByAward(int id);
        bool CreateAward(Award award);
        bool UpdateAward(Award award);
        bool DeleteAward(Award award);
        bool AwardExists(int id);
        bool Save();

    }
}
