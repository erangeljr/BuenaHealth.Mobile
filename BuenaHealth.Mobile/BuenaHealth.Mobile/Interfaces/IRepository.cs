using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BuenaHealth.Mobile.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        IQueryable<T> Find(Expression<Func<T, bool>> predicate);
        IQueryable<T> FindWithChildren(Expression<Func<T, bool>> predicate, string[] children);
        T Single(Expression<Func<T, bool>> predicate);
        T SingleOrDefault(Expression<Func<T, bool>> predicate);
        T First(Expression<Func<T, bool>> predicate);
        T GetById(object id);

        void Add(T entity);
        void Delete(T entity);
        void Attach(T entity);
        void Update(T entity);
        void AddRange(IEnumerable<T> entities);
    }
}
