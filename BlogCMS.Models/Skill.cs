using System;
using System.ComponentModel.DataAnnotations;
using BlogCMS.Models.Enum;

namespace BlogCMS.Models
{
    public class Skill
    {
        [Key]
        public int SkillId { get; set; }
        public int OwnedId { get; set; }

        public string SkillName { get; set; }
        public DateTime StartedAt { get; set; }
        public SkillType Type { get; set; } 
        public int KnowledgeLevel { get; set; }
        public string AvatarUrl { get; set; }

        public Owner Owner { get; set; }
    }
}
