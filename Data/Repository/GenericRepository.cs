using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Data.Repository
{
    public class GenericRepository <T> : IGenericRepository<T> where T : class
    {
        private readonly ProjectDbContext _context;
        private DbSet<T> _entity;
        public GenericRepository(ProjectDbContext context)
        {
            _context = context;
            _entity = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _entity.ToList();
        }

        public IQueryable<T> GetAllAsQueryable()
        {
            return _entity.AsQueryable();
        }
        public T Get(long id)
        {
            return _entity.Find(id);
        }
        public T Get(int id)
        {
            return _entity.Find(id);
        }
        public T Get(string id)
        {

            return _entity.Find(id);
        }
        public void Add(T entity)
        {
            _entity.Add(entity);
        }

        public void Update(T entity)
        {
            _context.Attach(entity);

            _context.Entry(entity).State = EntityState.Modified;

        }

        public void Delete(T entity)
        {
            _entity.Remove(entity);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).ToList();
        }

        public T FindBy(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).FirstOrDefault();
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
        public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).ToList();
        }
        public IQueryable<T> GetAsQueryable()
        {
            return _entity.AsQueryable();
        }
    }
}
