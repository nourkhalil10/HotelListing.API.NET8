using Microsoft.EntityFrameworkCore;

namespace HotelListing.API.Data;

public class HotelListingDbContext : DbContext
{
    public HotelListingDbContext(DbContextOptions options) : base(options)
    {
        
    }

    public DbSet<Hotel> Hotels { get; set; }
    public DbSet<Country> Countries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Country>().HasData(
            new Country { Id = 1, Name = "Egypt", ShortName = "EG",},
            new Country { Id=2, Name= "Morocco", ShortName = "MO"},
            new Country { Id = 3, Name="Cayman Island", ShortName="CI"}
            );

        modelBuilder.Entity<Hotel>().HasData(
            new Hotel { Id = 1, Name="Hilton Resort", Address="test", CountryId=1, Rating=4.5},
            new Hotel { Id = 2, Name="Landmark Resort", Address="test", CountryId=2, Rating=3},
            new Hotel { Id = 3, Name="Helanan Hotel", Address="test", CountryId=3, Rating=2},
            new Hotel { Id = 4, Name="Palma Resort", Address="test", CountryId=1, Rating=5}
            );
    }
}
