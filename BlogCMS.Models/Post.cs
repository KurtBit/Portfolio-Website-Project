using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlogCMS.Models
{
    public class Post
    {
        private ICollection<Tag> _tags;
             
        public Post()
        {
            this._tags = new HashSet<Tag>();
        }

        [Key]
        public int PostId { get; set; }
        [Required]
        public string UserId { get; set; }

        [MaxLength(256)]
        [Required]
        public string Title { get; set; }
        public string Slug { get; set; }
        [Required]
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public int IsDeleted { get; set; }
        
        public virtual User User { get; set; }
        public virtual ICollection<Tag> Tags
        {
            get { return this._tags; }
            set { this._tags = value; }
        }

    }
}
