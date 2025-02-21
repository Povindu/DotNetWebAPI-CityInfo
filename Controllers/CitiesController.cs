using System;
using System.Security.Cryptography.X509Certificates;
using CityInfo.models;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.Controllers;



[ApiController]
[Route("api/cities")]
public class CitiesController : ControllerBase
{

    private readonly CitiesDataStore _citiesDataStore;


    public CitiesController(CitiesDataStore citiesDataStore)
    {
        _citiesDataStore = citiesDataStore;
    }

    [HttpGet]
    public ActionResult<IEnumerable<CityDTO>> GetCities()
    {
        return Ok(_citiesDataStore.Cities);
    }




    [HttpGet("{id}")]
    public ActionResult<CityDTO> GetCity(int id)
    {
        var cityToReturn = _citiesDataStore.Cities.FirstOrDefault(c => c.Id == id);
        if (cityToReturn == null)
        {
            return NotFound();
        }
        return Ok(cityToReturn);
    }

}
