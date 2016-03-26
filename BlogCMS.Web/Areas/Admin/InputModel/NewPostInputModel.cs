using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogCMS.Web.Areas.Admin.InputModel
{
    public class NewPostInputModel
    {
        public NewPostInputModel()
        {
            Title = "Insert Title Here";
        }

        public string Title { get; set; }
        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Slug { get; set; }
    }
}
