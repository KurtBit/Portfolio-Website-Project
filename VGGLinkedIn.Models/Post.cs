using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace VGGLinkedIn.Models
{
    public class Post
    {
        //private ICollection<Tag> _tags;

        //public Post()
        //{
        //    _tags = new HashSet<Tag>();
        //}

        public int Id { get; set; }

        public string Title { get; set; }
        public string Slug { get; set; }
        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public bool IsDeleted { get { return DeletedAt != null; } }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual User User { get; set; }

        //public virtual ICollection<Tag> Tags
        //{
        //    get { return this._tags; }
        //    set { this._tags = value; }
        //}
    }
}
