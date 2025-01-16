using Freelancer.Data;
using Freelancer.Dtos.Responce;
using Freelancer.Models;
using Freelancer.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Freelancer.Repository
{
    public class LocationRepo : ILocationRepo
    {
        private readonly ApplicationDbContext _context;
        public LocationRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Location>> GetAll()
        {
            var locations=await _context.Locations.ToListAsync();
            return locations;
        }
        public async Task<StatusActionRepocs> Create(Location locaton)
        {
            try
            {
                await _context.Locations.AddAsync(locaton);
                await _context.SaveChangesAsync();
                return new StatusActionRepocs
                {
                    IsSucess = true,
                    Message = "Location add successfully"
                };
            }
            catch (Exception ex)
            {
                return new StatusActionRepocs
                {
                    IsSucess= false,
                    Message = ex.Message
                };
            }

        }

        public async Task<StatusActionRepocs> Update(Location location,string newName)
        {
            location.LocationName = newName.ToLower();
            _context.SaveChanges();
            return new StatusActionRepocs
            {
                IsSucess = false,
                Message = "Location name changed"
            };
        }

        public async Task<Location> GetByName(string locationName)
        {
            var locations =await _context.Locations.ToListAsync();
            return locations.Where(l=>l.LocationName == locationName).FirstOrDefault();
        }

        public async Task<StatusActionRepocs> Delete(Location location)
        {
            try
            {
                _context.Locations.Remove(location);
                _context.SaveChanges();
                return new StatusActionRepocs
                {
                    IsSucess = true,
                    Message = "location deleted successfully"
                };
            }
            catch (Exception ex)
            {
                return new StatusActionRepocs
                {
                    IsSucess = false,
                    Message = ex.Message
                };
            }
        }
    }
}
