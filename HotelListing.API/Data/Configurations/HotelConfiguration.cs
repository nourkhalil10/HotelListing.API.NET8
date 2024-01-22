using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelListing.API.Data.Configurations
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasData(
            new Hotel { Id = 1, Name = "Hilton Resort", Address = "test", CountryId = 1, Rating = 4.5 },
            new Hotel { Id = 2, Name = "Landmark Resort", Address = "test", CountryId = 2, Rating = 3 },
            new Hotel { Id = 3, Name = "Helanan Hotel", Address = "test", CountryId = 3, Rating = 2 },
            new Hotel { Id = 4, Name = "Palma Resort", Address = "test", CountryId = 1, Rating = 5 }
            );
        }
    }
}
