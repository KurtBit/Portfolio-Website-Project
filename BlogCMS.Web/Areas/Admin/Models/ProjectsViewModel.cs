using System;

namespace BlogCMS.Web.Areas.Admin.Models
{
    public class ProjectsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public string Slug { get; set; }
        public TimeSpan? TimeSpan { get; set; }
        public int IsDeleted { get; set; }
        public string Url { get; set; }
        public string ImgFrameUrl { get; set; }
    }
}