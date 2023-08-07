using CarReview.Models;

namespace CarReview.Interfaces
{
    public interface IAwardRepository
    {
        IEnumerable<Award> GetAwards();

        Award GetAward(int id);

        AwardProvider GetAwardProviderByAward(int id);
    }
}
