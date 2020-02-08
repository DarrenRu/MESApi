using System;
using System.Linq;
using System.Linq.Expressions;
using ITRI.Models.Entities;
using ITRI.Models.Interface;
using Microsoft.EntityFrameworkCore;

namespace ITRI.Models
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private qrcodeContext _context { get; set; }
        public Repository() : this(new qrcodeContext())
        {
        }

        public Repository(qrcodeContext context)
        {
            this._context = context ?? throw new ArgumentNullException("context");
        }

        public void Create(T instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            else
            {
                this._context.Set<T>().Add(instance);
                this.SaveChanges();
            }
        }

        public void Update(T instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            else
            {
                this._context.Entry(instance).State = EntityState.Modified;
                this.SaveChanges();
            }

        }

        public void Delete(T instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            else
            {
                this._context.Entry(instance).State = EntityState.Deleted;
                this.SaveChanges();
            }
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return this._context.Set<T>().FirstOrDefault(predicate);
        }

        public IQueryable<T> GetAll()
        {
            return this._context.Set<T>().AsQueryable();
        }

        public IQueryable<T> Query()
        {
            return this._context.Query<T>().AsQueryable();
        }

        public void SaveChanges()
        {
            this._context.SaveChanges();
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this._context != null)
                {
                    this._context.Dispose();
                    this._context = null;
                }
            }
        }
    }
}
