using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CityInfo.Entities
{
    public class PointOfInterest
    {


        [Key] // Assign Id as primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required]
        [MaxLength(50)]
        public string Name { get; set; }


        [MaxLength(250)]
        public string? Description { get; set; }



        [ForeignKey("CityId")] //This is optional as Entity Framework assign primary key of the related class as foreign key
        public City? City { get; set; }
        public int CityId { get; set; }




        //Constructor used for assigning name attribute
        public PointOfInterest(string name)
        {
            Name = name;
        }



    }
}
