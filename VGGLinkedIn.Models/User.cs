using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace VGGLinkedIn.Models
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
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }

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
