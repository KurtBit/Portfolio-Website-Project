using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogCMS.Models
{
    public class SkillType
    {
        private ICollection<Skill> _skills;

        public SkillType()
        {
            _skills = new HashSet<Skill>();
        }

        [Key]
        public int SkillTypeId { get; set; }
        public int OwnerId { get; set; }

        public string SkillName { get; set; }

        public virtual Owner Owner { get; set; }

        public ICollection<Skill> Skills
        {
            get { return this._skills; }
            set { this._skills = value; }
        }
    }
}
