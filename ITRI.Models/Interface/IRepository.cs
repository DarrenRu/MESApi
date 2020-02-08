using System;
using System.Linq;
using System.Linq.Expressions;

namespace ITRI.Models.Interface
{
    public interface IRepository<T> : IDisposable where T : class
    {
        void Create(T instance);
        void Update(T instance);
        void Delete(T instance);
        T Get(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAll();
        IQueryable<T> Query();
        void SaveChanges();
    }
}
