using AutoMapper;
using CarReview.DTO;
using CarReview.Models;

namespace CarReview.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Car, CarDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<Country, CountryDto>();
            CreateMap<Owner, OwnerDto>();
            CreateMap<Award, AwardDto>();
            CreateMap<AwardProvider, AwardProviderDto>();
        }
    }
}
