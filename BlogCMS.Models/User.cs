using System.Collections.Generic;

namespace BlogCMS.Models
{
    public class User
    {
        private ICollection<Post> _posts;

        public User()
        {
            this._posts = new HashSet<Post>();
        }

        public int Id { get; set; }
        public string IdentityId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string FullName { get; set; }
        public string AvatarUrl { get; set; }
        public string Summary { get; set; }

        public virtual ICollection<Post> Posts
        {
            get { return this._posts; }
            set { this._posts = value; }
        }
    }
}
