namespace Freelancer.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string SkillName { get; set; }
        public ICollection<ProjectSkill> ProjectSkills { get; set; }
        
    }
}
