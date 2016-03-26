using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VGGLinkedIn.Web.Models
{
    public class PostViewModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}