using HotelListing.API.Models.Hotel;

namespace HotelListing.API.Models.Country;

public class CountryDto : CountryDtoBase
{
    public int Id { get; set; }
    public List<HotelDto> Hotels { get; set; }
}
