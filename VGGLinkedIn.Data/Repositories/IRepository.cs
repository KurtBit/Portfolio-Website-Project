using System.Linq;

namespace VGGLinkedIn.Data.Repositories
{
    public interface IRepository<T>
    {
        IQueryable<T> All();

        T Find(object id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T enity);

        T Delete(object id);
    }
}
