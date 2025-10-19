using CityInfo.DbContexts;
using CityInfo.Entities;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace CityInfo.Services
{
    public class CityInfoRepository : ICityInfoRepository
    {

      

        //Repository acts as an intermediary between the application and the database, abstracting the data access logic
        
        
        //Constructor dependency injection of context
        private readonly CityInfoContext _context;
        public CityInfoRepository(CityInfoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            // In here "?? throw new ArgumentNullException(nameof(context)) is used for only null checking the context
            // Otherwise just using _context = context will work

            // The "??" known as null-coalescing operator, executes the righthand side operation only if left hand side is null

        }



        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            return await _context.Cities.OrderBy(c => c.Name).ToListAsync();
        }



        public async Task<City?> GetCityAsync(int cityId, bool includePointsOfInterest)
        {
            if (includePointsOfInterest == true)
            {
                return await _context.Cities.Include(c => c.PointsOfInterests)
                    .Where(c => c.Id == cityId).FirstOrDefaultAsync();
            }

            return await _context.Cities.Where(c => c.Id == cityId).FirstOrDefaultAsync();
        }




        public async Task<PointOfInterest?> GetPointOfInterestForCityAsync(
            int cityId, int pointOfInterestId)
        {
            return await _context.PointsOfInterest
                .Where(p => p.CityId == cityId && p.Id == pointOfInterestId)
                .FirstOrDefaultAsync();
        }




        public async Task<IEnumerable<PointOfInterest>> GetPointsOfInterestForCityAsync(int cityId)
        {
            return await _context.PointsOfInterest
                .Where(p => p.CityId == cityId)
                .ToListAsync();
        }
    }
}
