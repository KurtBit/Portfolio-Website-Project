using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogCMS.Models
{
    public class Owner
    {
        private ICollection<Project> _projects;

        public Owner()
        {
            this._projects = new HashSet<Project>();
        }

        [Key]
        public int OwnerId { get; set; }
        [Required]
        public string UserId { get; set; }

        [MaxLength(256)]
        public string AvatarUrl { get; set; }
        public string AboutMe { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Project> Projects
        {
            get { return this._projects; }
            set { this._projects = value; }
        }
    }
}
