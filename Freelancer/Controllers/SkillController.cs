using Freelancer.Models;
using Freelancer.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Freelancer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private readonly ISkillRepo _skillRepo;
        public SkillController(ISkillRepo skillRepo)
        {
            _skillRepo = skillRepo;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var skills=await _skillRepo.GetAll();
            return Ok(skills);
        }
        
        [HttpGet]
        [Route("GetByName")]
        public async Task<IActionResult> GetByName([FromQuery] string name)
        {
            var find_skill=_skillRepo.GetByName(name);
            if(find_skill == null)
            {
                return NotFound("this skill is not exists");
            }
            else
            {
                return Ok(find_skill);
            }
        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromQuery] string skill_name)
        {
            Skill skill = new Skill
            {
                SkillName = skill_name
            };

            var result = await _skillRepo.Create(skill);
            if(result.IsSucess)
            {
                return Ok(result.Message);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete([FromQuery] string skillName)
        {
            var existingSkill=await _skillRepo.GetByName(skillName.ToLower());
            if(existingSkill == null)
            {
                return NotFound("can't find the skill,skill is not exist");
            }
            var result=await _skillRepo.Delete(existingSkill);
            if (result.IsSucess)
            {
                return Ok(result.Message);
            }
            else
            {
                return BadRequest($"Failed to delete skill [{skillName}]");
            }
        }
        [HttpPut]
        [Route("Update/{id:int}")]
        public async Task<IActionResult> Update([FromRoute]int id, [FromQuery]string newSkillame)
        {
            try
            {
                var result=await _skillRepo.Update(newSkillame, id);
                if(result.IsSucess)
                {
                    return Ok(result.Message);
                }
                else
                {
                    return BadRequest(result.Message);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
