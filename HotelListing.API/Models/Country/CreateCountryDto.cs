using System.ComponentModel.DataAnnotations;

namespace HotelListing.API.Models.Country;

public class CreateCountryDto : CountryDtoBase
{
    
}

public class UpdateCountryDto : CountryDtoBase
{
    public int Id { get; set; }
}
