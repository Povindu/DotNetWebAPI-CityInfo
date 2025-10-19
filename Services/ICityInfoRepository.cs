using CityInfo.Entities;

namespace CityInfo.Services
{
    public interface ICityInfoRepository
    {

        //This Repository Interface is used to define the signatures of the methods to that deal with database 


        // Task< > is used to make a method async, we can omit it when we don't want to make method async 

        // We can use IQueryable<> instead of IEnumerable<>.
        // With IQueryable<> where we can use methods such as "orderby", "where".
        // But it leaks presistance related logic to outside. This violates repository pattern


        Task<IEnumerable<City>> GetCitiesAsync();
        Task<City?> GetCityAsync(int cityId, bool includePointsOfInterest);
        Task<IEnumerable<PointOfInterest>> GetPointsOfInterestForCityAsync(int cityId);
        Task<PointOfInterest?> GetPointOfInterestForCityAsync(int cityId, int pointOfInterestId);

    }
}
