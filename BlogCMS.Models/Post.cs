using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace VGGLinkedIn.Models
{
    public class Post
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Slug { get; set; }
        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public bool IsDeleted { get { return DeletedAt != null; } }

        public int UserId { get; set; }
        public virtual User User { get; set; }

    }
}
