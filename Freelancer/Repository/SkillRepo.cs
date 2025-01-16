using Freelancer.Data;
using Freelancer.Dtos.Responce;
using Freelancer.Models;
using Freelancer.Repository.Interface;

namespace Freelancer.Repository
{
    public class SkillRepo : ISkillRepo
    {
        private readonly ApplicationDbContext _context;
        public SkillRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task<StatusActionRepocs> Create(Skill skill)
        {
            throw new NotImplementedException();
        }

        public Task<StatusActionRepocs> Delete(Skill skill)
        {
            throw new NotImplementedException();
        }

        public Task<List<Skill>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Skill> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<StatusActionRepocs> Update(Skill skill)
        {
            throw new NotImplementedException();
        }
    }
}
