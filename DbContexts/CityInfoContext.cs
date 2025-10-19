using CityInfo.Entities;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

namespace CityInfo.DbContexts
{
    public class CityInfoContext : DbContext
    {
        public DbSet<City> Cities { get; set; }

        public DbSet<PointOfInterest> PointsOfInterest { get; set; }

        //Connect to DB 
        //Method 1: Add sqlite using a connection string
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("connectionstring");
        //    base.OnConfiguring(optionsBuilder);
        //}

        // Method 2: uisng consructor injection. we inject nessasary data from program.cs class when registering service
        public CityInfoContext(DbContextOptions<CityInfoContext> options2) : base(options2)
        {

        }



          

        //Use to seed the database
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
