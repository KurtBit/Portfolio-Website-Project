using System;

namespace BlogCMS.Web.Areas.Admin.InputModel
{
    public class PostInputModel
    {
        public PostInputModel()
        {
            Title = "Insert Title Here";
        }

        public string Title { get; set; }
        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Slug { get; set; }
    }
}
