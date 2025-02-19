using CityInfo.models;
using CityInfo.Models;
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


        [HttpGet("{POIId}" , Name = "GetPointOfInterest")]
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

        [HttpPost]
        public ActionResult<PointOfInterestDTO> CreatePointOfInterest(
            int cityId,
            PointOfInterestForCreationDTO pointOfInterest)
            // we do not need to mention [FromBody] annotation with above variable
        {

            


            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if(city == null)
            {
                return NotFound();
            }

            var maxPointOfInterestId = CitiesDataStore.Current.Cities.SelectMany(c => c.PointOfInterests).Max(p => p.Id);

            var finalPointOfInterest = new PointOfInterestDTO()
            {
                Id = ++maxPointOfInterestId,
                Name = pointOfInterest.Name,
                Description = pointOfInterest.Description
            };

            city.PointOfInterests.Add(finalPointOfInterest);

            //return CreatedAtRoute("GetPointOfInterest", new
            //{
            //    cityId = cityId,
            //    POIId = finalPointOfInterest.Id
            //    // These field names should match param names of the HttpGet

            //},
            //finalPointOfInterest);

            //return Ok(finalPointOfInterest);
            return Created("wedwqe",finalPointOfInterest);

            //Reponds with created file (finalPointOfInterest). Uses "GetPointOfInterest" API Endpoint as the value of location header





        }
    }
}
