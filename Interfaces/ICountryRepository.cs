using CarReview.Models;

namespace CarReview.Interfaces
{
    public interface ICountryRepository
    {
        ICollection<Country> GetCountries();
        Country GetCountry(int id);
        Country GetCountryByOwner(int id);
        bool CountryExists(int id);
    }
}
