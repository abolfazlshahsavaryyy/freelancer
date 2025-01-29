using Freelancer.Dtos.Skill;
using Freelancer.Models;

namespace Freelancer.Dtos.Project
{
    public class ProjectDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal budget { get; set; }
        public int time { get; set; }
        public Location Location { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public List<SkillDto>? skills { get; set; }
    }
}
