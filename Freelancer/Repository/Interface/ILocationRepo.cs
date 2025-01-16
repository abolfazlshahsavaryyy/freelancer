using Freelancer.Dtos.Responce;
using Freelancer.Models;

namespace Freelancer.Repository.Interface
{
    public interface ILocationRepo
    {
        Task<List<Location>> GetAll();
        Task<Location> GetByName(string locationName);
        Task<StatusActionRepocs> Create(Location location);
        Task<StatusActionRepocs> Delete(Location location);
        Task<StatusActionRepocs> Update(Location location,string newName);
    }
}
