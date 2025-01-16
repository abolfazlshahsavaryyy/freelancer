using Freelancer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Freelancer.Data
{
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option):base(option) { }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<ProjectSkill> ProjectSkills { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ProjectSkill>()
                .HasKey(ps => new { ps.ProjectId, ps.SkillId });

            builder.Entity<ProjectSkill>()
                .HasOne(ps => ps.Project)
                .WithMany(ps => ps.ProjectSkills)
                .HasForeignKey(ps => ps.ProjectId);

            builder.Entity<ProjectSkill>()
                .HasOne(ps=>ps.Skill)
                .WithMany(ps=>ps.ProjectSkills)
                .HasForeignKey(ps=>ps.SkillId);
        }
    }
}
