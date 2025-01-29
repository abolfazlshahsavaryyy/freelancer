using Freelancer.Dtos.Responce;
using Freelancer.Models;

namespace Freelancer.Repository.Interface
{
    public interface ISkillRepo
    {
        Task<List<Skill>> GetAll();
        Task<Skill> GetByName(string name);
        Task<RepositoryResult> Create(Skill skill);
        Task<RepositoryResult> Update(string skillName,int id);
        Task<RepositoryResult> Delete(Skill skill);
    }
}
