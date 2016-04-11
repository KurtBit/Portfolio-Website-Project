using System;
using System.ComponentModel.DataAnnotations;

namespace BlogCMS.Models
{
    public class Skill
    {
        [Key]
        public int SkillId { get; set; }
        public int SkillTypeId { get; set; }
        
        public string SkillName { get; set; }
        public DateTime StartedAt { get; set; }
        public int KnowledgeLevel { get; set; }
        public string AvatarUrl { get; set; }

        public SkillType SkillType { get; set; }
    }
}
