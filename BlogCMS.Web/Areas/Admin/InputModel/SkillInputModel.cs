using System;
using BlogCMS.Models.Enum;


namespace BlogCMS.Web.Areas.Admin.InputModel
{
    public class SkillInputModel
    {
        public SkillInputModel()
        {
            StartedAt = DateTime.Now;
        }

        public string SkillName { get; set; }
        public DateTime StartedAt { get; set; }
        public SkillType Type { get; set; } 
        public int KnowledgeLevel { get; set; }
        public string AvatarUrl { get; set; }
    }
}
