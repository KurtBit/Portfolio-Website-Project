using System.Data.Entity;
using System.Linq;

namespace VGGLinkedIn.Data.Repositories
{
    class GenericRepository<T> :IRepository<T> where T : class
    {
        private DbContext _context;
        private IDbSet<T> _set;

        public GenericRepository(DbContext context)
        {
            this._context = context;
            this._set = context.Set<T>();
        }

        public IDbSet<T> Set
        {
            get { return this._set; }
        }

        public IQueryable<T> All()
        {
            return this._set;
        }

        public T Find(object id)
        {
            return this._set.Find(id);
        }

        public void Add(T entity)
        {
            this.ChangeState(entity, EntityState.Added);
        }

        public void Update(T entity)
        {
            this.ChangeState(entity, EntityState.Modified);
        }

        public void Delete(T entity)
        {
            this.ChangeState(entity, EntityState.Deleted);
        }

        public T Delete(object id)
        {
            var entity = this.Find(id);
            this.Delete(entity);
            return entity;
        }

        private void ChangeState(T entity, EntityState state)
        {
            var entry = this._context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this._set.Attach(entity);
            }
            entry.State = state;
        }
    }
}
