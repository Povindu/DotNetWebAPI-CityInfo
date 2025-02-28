using CityInfo.Entities;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

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


        public CityInfoContext(DbContextOptions<CityInfoContext> options2) : base(options2)
        {

        }



          

        //Used to seed the database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .HasData(
                new City("New York City")
                {
                    Id = 1,
                    Description = "Thwfwefwefewf"
                },
                new City("Antwerp")
                {
                    Id = 2,
                    Description = "wefwefw"
                },
                new City("Paris")
                {
                    Id = 3,
                    Description = "ergregwgwg"
                });

            modelBuilder.Entity<PointOfInterest>()
                .HasData(
                new PointOfInterest("Park")
                {
                    Id = 1,
                    CityId = 1,
                    Description = "efwefwef"
                },
                new PointOfInterest("State")
                {
                    Id = 2,
                    CityId = 1,
                    Description = "wefwefwef"
                },
                new PointOfInterest("Cathedral")
                {
                    Id = 3,
                    CityId = 2,
                    Description = "Cathewfwefwefwe"
                });

            base.OnModelCreating(modelBuilder);
        }





    }
}
