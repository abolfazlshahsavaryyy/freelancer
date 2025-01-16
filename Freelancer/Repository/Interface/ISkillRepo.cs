using Freelancer.Dtos.Responce;
using Freelancer.Models;

namespace Freelancer.Repository.Interface
{
    public interface ISkillRepo
    {
        Task<List<Skill>> GetAll();
        Task<Skill> GetById(int id);
        Task<StatusActionRepocs> Create(Skill skill);
        Task<StatusActionRepocs> Update(Skill skill);
        Task<StatusActionRepocs> Delete(Skill skill);
    }
}
