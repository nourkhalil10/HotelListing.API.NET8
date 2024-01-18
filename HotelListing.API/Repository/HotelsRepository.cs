using HotelListing.API.Data;
using HotelListing.API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.API.Repository
{
    public class HotelsRepository : GenericRepository<Hotel>, IHotelsRepository
    {
        private readonly HotelListingDbContext _context;

        public HotelsRepository(HotelListingDbContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<Hotel> GetDetails(int? id)
        {
            return await _context.Hotels.Include(q => q.Country)
                .FirstOrDefaultAsync(q => q.Id == id);
        }
    }
}
