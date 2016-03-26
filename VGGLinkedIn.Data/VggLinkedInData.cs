using System;
using System.Collections.Generic;
using VGGLinkedIn.Data.Repositories;
using VGGLinkedIn.Models;

namespace VGGLinkedIn.Data
{
    public class VggLinkedInData : IVggLinkedInData
    {
        private IVggLinkedInContext _context;
        private IDictionary<Type, object> _repositories;

        public VggLinkedInData(IVggLinkedInContext context)
        {
            this._context = context;
            this._repositories = new Dictionary<Type, object>();
        }

        public IRepository<User> Users
        {
            get { return this.GetRepository<User>(); }
        }

        public IRepository<Post> Posts
        {
            get { return this.GetRepository<Post>(); }
        }

        public IRepository<Tag> Tags
        {
            get { return this.GetRepository<Tag>(); }
        }

        public int SaveChanges()
        {
            return this._context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var type = typeof (T);
            if (!this._repositories.ContainsKey(type))
            {
                var typeOfRepository = typeof (GenericRepository<T>);
                var repository = Activator.CreateInstance(typeOfRepository, this._context);
                this._repositories.Add(type, repository);
            }
            return (IRepository<T>) this._repositories[type];
        }
    }
}
