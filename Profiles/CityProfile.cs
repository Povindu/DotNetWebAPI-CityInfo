using AutoMapper;


namespace CityInfo.Profiles
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            //This is used to map City entity to CityWithoutPointsOfInterestDTO
            CreateMap<Entities.City, Models.CityWithoutPointsOfInterestDTO>();
            CreateMap<Entities.City, Models.CityDTO>();
        }
    }
}
