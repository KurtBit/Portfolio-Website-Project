using System;
using System.ComponentModel.DataAnnotations;

namespace BlogCMS.Models
{
    public class Skill
    {
        [Key]
        public int SkillId { get; set; }
        public int OwnedId { get; set; }

        public DateTime StartedAt { get; set; }
        public string Type { get; set; } // Maybe ENum
        public int KnowledgeLevel { get; set; }

        public Owner Owner { get; set; }
    }
}
