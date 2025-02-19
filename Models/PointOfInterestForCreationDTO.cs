using System.ComponentModel.DataAnnotations;

namespace CityInfo.Models
{
    public class PointOfInterestForCreationDTO
    {
        //[Required]
        public string Name { get; set; } = string.Empty;

        [MaxLength(50)]
        public string? Description { get; set; }
    }
}
