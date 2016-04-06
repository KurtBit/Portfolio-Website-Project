using System;

namespace BlogCMS.Web.Areas.Admin.InputModel
{
    public class ProjectInputModel
    {
        public ProjectInputModel()
        {
            StartDate = DateTime.Now;
            EndDate = DateTime.Now;
        }

        public string Title { get; set; }
        public string Content { get; set; }
        public string Slug { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime StartDate { get; set; }
        public string Url { get; set; }
        public string ImgFrameUrl { get; set; }
    }
}