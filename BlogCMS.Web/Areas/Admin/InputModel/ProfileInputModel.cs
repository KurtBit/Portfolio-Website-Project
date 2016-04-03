using System.ComponentModel.DataAnnotations;

namespace BlogCMS.Web.Areas.Admin.InputModel
{
    public class ProfileInputModel
    {
        [MaxLength(255)]
        public string AvatarUrl { get; set; }
        public string AboutMe { get; set; }
    }
}