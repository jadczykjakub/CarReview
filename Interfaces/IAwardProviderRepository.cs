using CarReview.Models;

namespace CarReview.Interfaces
{
    public interface IAwardProviderRepository
    {
        IEnumerable<AwardProvider> GetAwardProviders();
        AwardProvider GetAwardProvider(int id);
        IEnumerable<Award> GetAwardByAwardProvider(int id);
    }
}
