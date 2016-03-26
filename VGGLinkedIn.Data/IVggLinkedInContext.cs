using System.Data.Entity;
using VGGLinkedIn.Models;

namespace VGGLinkedIn.Data
{
    public interface IVggLinkedInContext
    {
        IDbSet<Post> Post { get; set; }
        IDbSet<Tag> Tag { get; set; }

        int SaveChanges();
    }
}
