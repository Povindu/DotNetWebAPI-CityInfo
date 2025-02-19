using CityInfo.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.Controllers
{
    [Route("api/cities/{cityId}/pointsofinterest")]
    [ApiController]
    public class PointsOfInterestController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<PointOfInterestDTO>> GetPointsOfInterst(int cityId)
        {

            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }
            return Ok(city.PointOfInterests);
        }

        [HttpGet("{POIId}")]
        public ActionResult<PointOfInterestDTO> GetPointOfInterest(int cityId, int POIId)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => (c.Id == cityId));
            if (city == null)
            {
                return NotFound();
            }

            var POI = city.PointOfInterests.FirstOrDefault(p => p.Id == POIId);
            if (POI == null)
            {
                return NotFound();
            }

            return Ok(POI);

        }
    }
}
