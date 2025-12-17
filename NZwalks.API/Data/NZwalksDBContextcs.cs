using Microsoft.EntityFrameworkCore;
using NZwalks.API.Model.Domain;

namespace NZwalks.API.Data
{
    public class NZwalksDBContextcs : DbContext
    {
        public NZwalksDBContextcs(DbContextOptions<NZwalksDBContextcs> dbContextOption) : base(dbContextOption)
        {


        }

        // creates a table in the database 
        public DbSet<Difficulty> Difficulties { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Walk> Walks { get; set; }

        public DbSet<Image>Images { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seeding data for Difficulties 
            // Easy , Medium , Hard 

            var difficulities = new List<Difficulty>()
            {
                new Difficulty()
                {
                    ID = Guid.Parse("335d8255-9953-4845-8581-788ac4e153d8"),
                    Name = "Easy"
                },
                new Difficulty()
                {
                    ID = Guid.Parse("f7ef4ca5-e069-49cc-9b39-1a90d1438418"),
                    Name = "Medium"
                },
                new Difficulty()
                {
                    ID = Guid.Parse("14491e4d-9abb-44af-8b56-701c0b06b09d"),
                    Name = "Hard"
                }

            };
            
            //Seed difficulties to the database
            modelBuilder.Entity<Difficulty>().HasData(difficulities);


            // Seed data for the regions 

            var regions = new List<Region>()
            {
                new Region()
                {
                    Id = Guid.Parse("311d028f-6801-40a1-85d9-32834d8f3e04"),
                    Name = "Wellington",
                    Code = "WGN",
                    RegionImageurl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSIIodJ7L7jxCAiZHGLKTbNKYLND-vgPS3vbA&s"
                },
                new Region()
                {
                    Id = Guid.Parse("f7109940-19f0-48d4-97fd-898942b0ade7"),
                    Name = "Bay of Plenty",
                    Code = "BOP",
                    RegionImageurl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT6lhHopLJArrwJ4nyxk1AtR7m72M71_dFbVw&s"
                },
                new Region()
                {
                    Id = Guid.Parse("a1cdec49-afa7-47b7-9584-f82252f37da6"),
                    Name = "Nelson",
                    Code = "NSN",
                    RegionImageurl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQZ9kBp01al31iWgPGCja8IOlWL1bG3RS2wLw&s"
                },
                new Region()
                {
                    Id = Guid.Parse("fbd1b7d6-3308-42bb-a98e-2f1500c59673"),
                    Name = "Southland",
                    Code = "STL",
                    RegionImageurl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTZjn1lpvZhzBjiTLktxnJ5xUM6qqIPabUtkQ&s"
                },



            };

            modelBuilder.Entity<Region>().HasData(regions);

        }

    }
}