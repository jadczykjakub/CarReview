using CarReview.Models;

namespace CarReview.Interfaces
{
    public interface IAwardProviderRepository
    {
        IEnumerable<AwardProvider> GetAwardProviders();
        AwardProvider GetAwardProvider(int id);
        IEnumerable<Award> GetAwardByAwardProvider(int id);
        bool AwardProviderExist(int id);
        bool CreateAwardProvider(AwardProvider awardProvider);
        bool UpdateAwardProvider(AwardProvider awardProvider);
        bool DeleteAwardProvider(AwardProvider awardProvider);
        bool Save();
    }
}
