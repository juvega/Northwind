using System;
using System.Collections.Generic;

namespace Northwind.Api.Repository.MySql
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public readonly NorthwindDbContext _context;
        public Repository(NorthwindDbContext context)
        {
            _context = context;
        }
        public int Create(T entity)
        {
            _context.Add(entity);
            return _context.SaveChanges();
        }

        public bool Delete(T entity)
        {
            _context.Remove(entity);
            return _context.SaveChanges() > 0;
        }

        public T Read(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public IEnumerable<T> ReadAll()
        {
            return _context.Set<T>();
        }

        public bool Update(T entity)
        {
            _context.Update(entity);
            return _context.SaveChanges() > 0;
        }
    }
}
