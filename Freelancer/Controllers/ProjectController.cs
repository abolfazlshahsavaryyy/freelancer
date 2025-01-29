using Freelancer.Dtos;
using Freelancer.Mapper;
using Freelancer.Models;
using Freelancer.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Freelancer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectRepository _projectRepository;
        public ProjectController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result=await _projectRepository.GetAll();
            var projects=result.contextBody as IEnumerable<Project>;
            var projectDto = projects.Select(p => new ProjectDto
            {
                Id = p.Id,
                Title = p.Title,
                Description = p.Description,
                time=p.time,
                Created=p.Created,
                budget=p.budget,
                skills=p.ProjectSkills.Select(ps=>ps.Skill.SkillToSkillDto()).ToList(),
                Location=p.Location
            }).ToList();
            if (result.IsSucess)
            {
                return Ok(projectDto);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
