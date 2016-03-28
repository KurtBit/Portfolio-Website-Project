using System;

namespace BlogCMS.Models
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

        public int IsDeleted { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }

    }
}
