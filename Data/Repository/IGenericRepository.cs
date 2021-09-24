using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Data.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(long id);
        T Get(int id);
        T Get(string id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        T FindBy(Expression<Func<T, bool>> predicate);
        bool SaveChanges();
        IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAllAsQueryable();
        IQueryable<T> GetAsQueryable();

    }
}
