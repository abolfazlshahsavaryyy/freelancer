using Freelancer.Dtos.Responce;
using Freelancer.Models;

namespace Freelancer.Repository.Interface
{
    public interface ISkillRepo
    {
        Task<List<Skill>> GetAll();
        Task<Skill> GetByName(string name);
        Task<StatusActionRepocs> Create(Skill skill);
        Task<StatusActionRepocs> Update(string skillName,int id);
        Task<StatusActionRepocs> Delete(Skill skill);
    }
}
