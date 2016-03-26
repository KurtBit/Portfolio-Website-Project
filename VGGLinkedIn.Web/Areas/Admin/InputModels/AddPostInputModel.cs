using System;

namespace VGGLinkedIn.Web.InputModels
{
    public class AddPostInputModel
    {
        public AddPostInputModel()
        {
            Title = "Insert Title Here";
        }

        public string Title { get; set; }
        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Slug { get; set; }
    }
}