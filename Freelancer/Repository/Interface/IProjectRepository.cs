using Freelancer.Dtos.Responce;
using Freelancer.Models;

namespace Freelancer.Repository.Interface
{
    public interface IProjectRepository
    {
        Task<RepositoryResult> GetAll();
        Task<RepositoryResult> GetById(int id);
        Task<RepositoryResult> Create(Project project);
        Task<RepositoryResult> AddSkillToProject(int skillId,int ProjectId);
        Task<RepositoryResult> SetLocationForProject(int locationId,int LocationId);
        Task<RepositoryResult> Update(Project project,int id);
        Task<RepositoryResult> RemoveSkillOfProject(int skillId,int ProjectId);
        Task<RepositoryResult> ChangeLocationOfProject(int projectId,int newLocationId);
        Task<RepositoryResult> Delete(int id);
    }
}
