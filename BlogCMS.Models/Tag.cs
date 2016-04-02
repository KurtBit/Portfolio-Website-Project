using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogCMS.Models
{
    public class Tag
    {
        [Key]
        public int TagId { get; set; }
        public int PostId { get; set; }

        public string Slug { get; set; }

        public Post Post { get; set; }
    }
}
