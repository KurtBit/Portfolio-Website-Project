﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;

namespace VGGLinkedIn.Models
{
    public class User
    {
        private ICollection<Post> _posts;

        public User()
        {
            this._posts = new HashSet<Post>();
        }

        public int Id { get; set; }
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