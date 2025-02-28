using System;
using CityInfo.Models;

namespace CityInfo;

public class CitiesDataStore
{
    public List<CityDTO> Cities { get; set; }

   // public static CitiesDataStore Current { get; } = new CitiesDataStore();


    public CitiesDataStore()
    {
        Cities = new List<CityDTO>(){
            new CityDTO(){
                Id = 1,
                Name = "New York",
                Description = "wwqdqwdqwdqwd",
                PointsOfInterest = new List<PointOfInterestDTO>(){
                    new PointOfInterestDTO() {
                        Id = 1,
                        Name = "Central Park",
                        Description = "wqdqwd"
                    },
                    new PointOfInterestDTO() {
                        Id = 2,
                        Name = "Empire State",
                        Description = "wqdqwd"
                    },
                }
            },
            new CityDTO(){
                Id = 2,
                Name = "Matara",
                Description = "wwqdqwdqwdqwd",
                PointsOfInterest = new List<PointOfInterestDTO>(){
                    new PointOfInterestDTO() {
                        Id = 1,
                        Name = "Central Park",
                        Description = "wqdqwd"
                    },
                    new PointOfInterestDTO() {
                        Id = 2,
                        Name = "Empire State",
                        Description = "wqdqwd"
                    },
                }
            },
            new CityDTO(){
                Id = 3,
                Name = "Galle",
                Description = "wwqdqwdqwdqwd",
                PointsOfInterest = new List<PointOfInterestDTO>(){
                    new PointOfInterestDTO() {
                        Id = 1,
                        Name = "Central Park",
                        Description = "wqdqwd"
                    },
                    new PointOfInterestDTO() {
                        Id = 2,
                        Name = "Empire State",
                        Description = "wqdqwd"
                    },
                }
            }

        };
    }



}
