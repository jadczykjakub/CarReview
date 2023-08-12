using AutoMapper;
using CarReview.Data;
using CarReview.Interfaces;
using CarReview.Models;

namespace CarReview.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private DataContext _context;

        public CountryRepository(DataContext context)
        {
            _context = context;
        }

        public bool CountryExists(int id)
        {
            return _context.Countries.Any(c => c.CountryId == id);
        }

        public ICollection<Country> GetCountries()
        {
            return _context.Countries.ToList();
        }

        public Country GetCountry(int id)
        {
            return _context.Countries.Where(c => c.CountryId == id).FirstOrDefault();
        }

        public Country GetCountryByOwner(int id)
        {
            return _context.Owners.Where(o => o.OwnerId == id).Select(o => o.Country).FirstOrDefault();
        }

        public bool CreateCountry(Country country)
        {
            _context.Add(country);
            return Save();
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();

            return saved > 0 ? true : false;
        }

        public bool UpdateCountry(Country country)
        {
            _context.Countries.Update(country);
            return Save();
        }

        public bool DeleteCountry(Country country)
        {
            _context.Countries.Remove(country);
            return Save();
        }
    }
}
