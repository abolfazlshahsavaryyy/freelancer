using Freelancer.Dtos.Skill;
using Freelancer.Models;

namespace Freelancer.Mapper
{
    public static class ExtensionMethodMapper
    {
        public static SkillDto SkillToSkillDto(this Skill? skill)
        {
            return new SkillDto
            {
                Id = skill.Id,
                SkillName = skill.SkillName,
            };
        }
    }
}
