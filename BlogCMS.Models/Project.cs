using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlogCMS.Models
{
    public class Project
    {
        private ICollection<Type> _types;

        public Project()
        {
            this._types = new HashSet<Type>();
        }

        [Key]
        public int ProjectId { get; set; }
        public int OwnerId { get; set; }

        [MaxLength(256)]
        public string Title { get; set; }
        public string Content { get; set; }
        public string Slug { get; set; }
        public TimeSpan? TimeSpan { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string Url { get; set; }
        public string ImgFrameUrl { get; set; }
        public int IsDeleted { get; set; }

        public virtual ICollection<Type> Types
        {
            get { return this._types; }
            set { this._types = value; }
        }
        public virtual Owner Owner { get; set; }
    }
}
