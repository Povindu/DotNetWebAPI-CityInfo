using System;
using System.Security.Cryptography.X509Certificates;
using CityInfo.models;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.Controllers;



[ApiController]
[Route("api/cities")]
public class CitiesController : ControllerBase
{


    [HttpGet]
    public ActionResult<IEnumerable<CityDTO>> GetCities()
    {
        return Ok(CitiesDataStore.Current.Cities);
    }




    [HttpGet("{id}")]
    public ActionResult<CityDTO> GetCity(int id)
    {
        var cityToReturn = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == id);
        if (cityToReturn == null)
        {
            return NotFound();
        }
        return Ok(cityToReturn);
    }

}
