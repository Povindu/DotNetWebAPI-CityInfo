using System;

namespace CityInfo.models;

public class CityDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }

    public ICollection<PointOfInterestDTO> PointOfInterests { get; set; }
        = new List<PointOfInterestDTO>();
}
