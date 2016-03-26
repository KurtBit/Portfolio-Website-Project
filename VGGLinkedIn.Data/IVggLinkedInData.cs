using VGGLinkedIn.Data.Repositories;
using VGGLinkedIn.Models;

namespace VGGLinkedIn.Data
{
    public interface  IVggLinkedInData
    {
        IRepository<User> Users { get; }
        IRepository<Post> Posts { get; }
        IRepository<Tag> Tags { get; }

        int SaveChanges();
    }
}
