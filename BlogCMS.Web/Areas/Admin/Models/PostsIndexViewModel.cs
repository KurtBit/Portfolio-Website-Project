using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogCMS.Web.Areas.Admin.Models
{
    public class PostsIndexViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Tag { get; set; }
        public DateTime PostedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}