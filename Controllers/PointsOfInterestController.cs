using CityInfo.Models;
using CityInfo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.Controllers;

[Route("api/cities/{cityId}/pointsofinterest")]
[ApiController]
public class PointsOfInterestController : ControllerBase
{

    // Logger
    private readonly ILogger<PointsOfInterestController> _logger;
    private readonly IMailService _mailService;
    private readonly CitiesDataStore _citiesDataStore;


    public PointsOfInterestController(
        ILogger<PointsOfInterestController> logger, 
        IMailService mailService, 
        CitiesDataStore citiesDataStore)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _mailService = mailService ?? throw new ArgumentNullException(nameof(mailService));
        _citiesDataStore = citiesDataStore ?? throw new ArgumentNullException(nameof(citiesDataStore));
    }



[HttpGet]
public ActionResult<IEnumerable<PointOfInterestDTO>> GetPointsOfInterest(int cityId)
{

    var city = _citiesDataStore.Cities.FirstOrDefault(c => c.Id == cityId);
    if (city == null)
    {
        //_logger.LogInformation($"City with requested id {cityId} wasn't found");
        return NotFound();
    }
    return Ok(city.PointsOfInterest);
}




[HttpGet("{POIId}" , Name = "GetPointOfInterest")]
public ActionResult<PointOfInterestDTO> GetPointOfInterest(int cityId, int POIId)
{
    var city = _citiesDataStore.Cities.FirstOrDefault(c => (c.Id == cityId));
    if (city == null)
    {
        return NotFound();
    }

    var POI = city.PointsOfInterest.FirstOrDefault(p => p.Id == POIId);
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
    // we do not need to mention [FromBody] annotation with above variable, compile already identifies that this varible comes from body of POST req
{

    var city = _citiesDataStore.Cities.FirstOrDefault(c => c.Id == cityId);
    if(city == null)
    {
        return NotFound();
    }


    var maxPointOfInterestId = _citiesDataStore.Cities.SelectMany(c => c.PointsOfInterest).Max(p => p.Id);

    var finalPointOfInterest = new PointOfInterestDTO()
    {
        Id = ++maxPointOfInterestId,
        Name = pointOfInterest.Name,
        Description = pointOfInterest.Description
    };

    city.PointsOfInterest.Add(finalPointOfInterest);

    return CreatedAtRoute("GetPointOfInterest", new
    {
        cityId = cityId,
        POIId = finalPointOfInterest.Id
        // These field names should match param names of the HttpGet

    },
    finalPointOfInterest);

        //return Ok(finalPointOfInterest);
        //return Created("RouteBlahBlah", finalPointOfInterest);




        //Reponds with created file (finalPointOfInterest). Uses "GetPointOfInterest" API Endpoint as the value of location header

    }




[HttpPut("{pointOfInterestid}")]
    public ActionResult UpdatePointOfInterest(
    int cityId, int pointOfInterestid, PointOfInterestForUpdateDTO pointOfInterest)
    {
    var tempCity = _citiesDataStore.Cities.FirstOrDefault(c => c.Id == cityId);

    if(tempCity == null)
    {
        return NotFound();
    }

    var tempPOI = tempCity.PointsOfInterest.FirstOrDefault(p => p.Id == pointOfInterestid);

    if(tempPOI == null)
    {
        return NotFound();
    }

    var finalPOI = new PointOfInterestForUpdateDTO()
        {
        Name = pointOfInterest.Name,
        Description = pointOfInterest.Description,
    };

    tempPOI.Name = finalPOI.Name;
    tempPOI.Description = finalPOI.Description;


    return NoContent();
}



[HttpPatch("{pointOfinterestid}")]
public ActionResult PartiallyUpdatePointOfInterest(
    int cityId, int pointOfInterestid, JsonPatchDocument<PointOfInterestForUpdateDTO> patchDocument)
{
    var tempCity = _citiesDataStore.Cities.FirstOrDefault(c => c.Id == cityId);

    if (tempCity == null)
    {
        return NotFound();
    }

    var tempPOI = tempCity.PointsOfInterest.FirstOrDefault(p => p.Id == pointOfInterestid);

    if (tempPOI == null)
    {
        return NotFound();
    }

    var PointOfInterestToPatch = new PointOfInterestForUpdateDTO
    {
        Name = tempPOI.Name,
        Description = tempPOI.Description
    };

    patchDocument.ApplyTo(PointOfInterestToPatch, ModelState);

    if (!ModelState.IsValid)
    {
        return BadRequest(ModelState);
    }

    if (!TryValidateModel(PointOfInterestToPatch))
    {
        return BadRequest(ModelState);
    }

    tempPOI.Name = PointOfInterestToPatch.Name;
    tempPOI.Description = PointOfInterestToPatch.Description;

    return NoContent();
}


[HttpDelete("{pointOfInterestId}")]
public ActionResult DeletePointOfInterest(int cityId , int pointOfInterestId)
{
    var tempCity = _citiesDataStore.Cities.FirstOrDefault(c => c.Id == cityId);

    if (tempCity == null)
    {
        return NotFound();
    }

    var tempPOI = tempCity.PointsOfInterest.FirstOrDefault(p => p.Id == pointOfInterestId);

    if (tempPOI == null)
    {
        return NotFound();
    }

    tempCity.PointsOfInterest.Remove(tempPOI);

    _mailService.Send("Point of interest deleted.",
        $"Point of interest {tempPOI.Name} with id {tempPOI.Id} was deleted");

    return NoContent();

}
    
        
    
    }
