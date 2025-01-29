using Freelancer.Data;
using Freelancer.Dtos.Responce;
using Freelancer.Models;
using Freelancer.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Freelancer.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ApplicationDbContext _context;

        public ProjectRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task<RepositoryResult> AddSkillToProject(int skillId, int ProjectId)
        {
            throw new NotImplementedException();
        }

        public Task<RepositoryResult> ChangeLocationOfProject(int projectId, int newLocationId)
        {
            throw new NotImplementedException();
        }

        public Task<RepositoryResult> Create(Project project)
        {
            throw new NotImplementedException();
        }

        public Task<RepositoryResult> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<RepositoryResult> GetAll()
        {
            try
            {
                var locations = await _context.Locations.ToListAsync();
                var Projects = await _context.Projects.Include(x=>x.ProjectSkills).ThenInclude(x=>x.Skill).ToListAsync();
                
                return new RepositoryResult
                {
                    IsSucess = true,
                    Message = "Data retirived",
                    contextBody = Projects
                };
            }
            catch (Exception ex)
            {
                return new RepositoryResult
                {
                    IsSucess = false,
                    Message = ex.Message,
                    contextBody = null
                };
            }
        }

        public Task<RepositoryResult> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<RepositoryResult> RemoveSkillOfProject(int skillId, int ProjectId)
        {
            throw new NotImplementedException();
        }

        public Task<RepositoryResult> SetLocationForProject(int locationId, int LocationId)
        {
            throw new NotImplementedException();
        }

        public Task<RepositoryResult> Update(Project project, int id)
        {
            throw new NotImplementedException();
        }
    }
}
