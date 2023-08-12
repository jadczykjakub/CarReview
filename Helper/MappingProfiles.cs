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
            CreateMap<CarDto, Car>();
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
            CreateMap<Country, CountryDto>();
            CreateMap<CountryDto, Country>();
            CreateMap<Owner, OwnerDto>();
            CreateMap<OwnerDto, Owner>();
            CreateMap<Award, AwardDto>();
            CreateMap<AwardDto, Award>();
            CreateMap<AwardProvider, AwardProviderDto>();
            CreateMap<AwardProviderDto, AwardProvider>();
        }
    }
}
