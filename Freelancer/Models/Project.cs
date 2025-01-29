using System.ComponentModel.DataAnnotations.Schema;

namespace Freelancer.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal budget {  get; set; }
        public int time { get; set;  }
        [ForeignKey("LocationId")]
        public Location? Location { get; set; }
        public int? LocationId { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public ICollection<ProjectSkill> ProjectSkills { get; set; }
         
    }
}
