using CityInfo.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.DbContexts
{
    public class CityInfoContext : DbContext
    {
        public DbSet<City> Cities { get; set; }

        public DbSet<PointOfInterest> PointsOfInterest { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("connectionstring");
        //    base.OnConfiguring(optionsBuilder);
        //}


        public CityInfoContext(DbContextOptions<CityInfoContext> options) : base(options)
        {

        }





    }
}
