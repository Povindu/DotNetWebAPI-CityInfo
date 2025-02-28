using System;
using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using CityInfo.Entities;
using CityInfo.Models;
using CityInfo.Services;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.Controllers;



[ApiController]
[Route("api/cities")]
public class CitiesController : ControllerBase
{

    private readonly ICityInfoRepository _cityInfoRepository;
    private readonly IMapper _mapper;


    public CitiesController(ICityInfoRepository cityInfoRepository,  IMapper mapper)
    {
        _cityInfoRepository = cityInfoRepository ??
                              throw new ArgumentNullException(nameof(cityInfoRepository));

        _mapper = mapper ?? throw new ArgumentNullException(nameof(cityInfoRepository));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CityWithoutPointsOfInterestDTO>>> GetCities()
    {
        var cityEntities = await _cityInfoRepository.GetCitiesAsync();
        // Above variable returns a list of CityDTO. But as we didnt populated the PointsOfInterest, that field in CityDTO remains empty
        // If we directly return this as a response, PointOfIntersts fields in the response will be empty.

        // Instead of this we map these data using a different DTO named CityWithoutPointsOfInterestDTO which doesnt have PointsOfIneterst property 



        // Following code manually maps 2 DTO's 
        //var results = new List<CityWithoutPointsOfInterestDTO>();
        //foreach (var cityEntity in cityEntities)
        //{
        //    results.Add(new CityWithoutPointsOfInterestDTO
        //    {
        //        Id = cityEntity.Id,
        //        Description = cityEntity.Description,
        //        Name = cityEntity.Name
        //    });
        //}


        //In here, mapper is used to automatically map 2 DTO's
        return Ok(_mapper.Map<IEnumerable<CityWithoutPointsOfInterestDTO>>(cityEntities));

         





        



    }




    [HttpGet("{id}")]
    public async Task<IActionResult> GetCity(int id, bool includePointsOfInterest = false)
    {
        var cityToReturn = await _cityInfoRepository.GetCityAsync(id,includePointsOfInterest);
        if (cityToReturn == null)
        {
            return NotFound();
        }


        if (includePointsOfInterest)
        {
            return Ok(_mapper.Map<CityDTO>(cityToReturn));
        }


        return Ok(cityToReturn);
    }

}
