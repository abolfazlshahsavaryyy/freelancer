using Freelancer.Dtos.Responce;
using Freelancer.Models;

namespace Freelancer.Repository.Interface
{
    public interface ILocationRepo
    {
        Task<List<Location>> GetAll();
        Task<Location> GetByName(string locationName);
        Task<RepositoryResult> Create(Location location);
        Task<RepositoryResult> Delete(Location location);
        Task<RepositoryResult> Update(Location location,string newName);
    }
}
