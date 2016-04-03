using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BlogCMS.Models
{
    public class User : IdentityUser
    {
        private ICollection<Post> _posts;

        public User()
        {
            this._posts = new HashSet<Post>();
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public string FullName { get; set; }
        public string AvatarUrl { get; set; }
        public string AboutMe { get; set; }
        public string Role { get; set; } // temp need to fix RoleManager

        public virtual ICollection<Post> Posts
        {
            get { return this._posts; }
            set { this._posts = value; }
        }
    }
}
