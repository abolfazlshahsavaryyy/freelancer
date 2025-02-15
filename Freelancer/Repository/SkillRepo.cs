﻿using Freelancer.Data;
using Freelancer.Dtos.Responce;
using Freelancer.Models;
using Freelancer.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Freelancer.Repository
{
    public class SkillRepo : ISkillRepo
    {
        private readonly ApplicationDbContext _context;
        public SkillRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<RepositoryResult> Create(Skill skill)
        {
            try
            {
                await _context.AddAsync(skill);
                await _context.SaveChangesAsync();
                return new RepositoryResult
                {
                    Message = "skill added",
                    IsSucess=true,
                };
            }
            catch (Exception ex)
            {
                return new RepositoryResult
                {
                    Message = ex.Message,
                    IsSucess = false,
                };

            }

        }

        public async Task<RepositoryResult> Delete(Skill skill)
        {
            try
            {
               
                _context.Remove(skill);
                await _context.SaveChangesAsync();
                return new RepositoryResult
                {
                    Message = "Skill removed",
                    IsSucess = true,

                };
            
            }
            catch (Exception ex)
            {
                return new RepositoryResult
                {
                    Message = ex.Message,
                    IsSucess = false,
                };
            }
        }

        public async Task<List<Skill>> GetAll()
        {
            var  skills=await _context.Skills.ToListAsync();
            if (skills.Count > 0)
            {
                return skills.DistinctBy(s => s.SkillName).ToList();
            }
            else
            {
                return skills.ToList();
            }
        }

        public async Task<Skill> GetByName(string name)
        {
            var skill=await _context.Skills.Where(s=>s.SkillName == name).FirstOrDefaultAsync();
            if(skill == null)
            {
                return null;
            }
            else
            {
                return skill;
            }
        }

       

        public async Task<RepositoryResult> Update(string skillName, int id)
        {
            var existingSkill=await _context.Skills.FindAsync(id);
            if (existingSkill == null)
            {
                return new RepositoryResult
                {
                    IsSucess = false,
                    Message = "can't find the skill"
                };
            }
            existingSkill.SkillName = skillName;
            try
            {
                await _context.SaveChangesAsync();
                return new RepositoryResult
                {
                    IsSucess = true,
                    Message = "skill name update"
                };
            }
            catch (Exception ex)
            {
                return new RepositoryResult
                {
                    IsSucess = false,
                    Message = ex.Message,
                };
            }

        }
    }
}
