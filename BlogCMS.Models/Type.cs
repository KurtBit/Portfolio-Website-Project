using System.ComponentModel.DataAnnotations;

namespace BlogCMS.Models
{
    public class Type
    {
        [Key]
        public int TypeId { get; set; }
        public int ProjectId { get; set; }

        public string Slug { get; set; }

        public Project Project { get; set; }
    }
}
