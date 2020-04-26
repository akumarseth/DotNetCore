using DataModel;
using DataAccess.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationDBContext _context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;
        public Repository(ApplicationDBContext context)
        {
            _context = context;
            entities = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }
        public T GetById(Guid id)
        {
            return entities.SingleOrDefault(s => s.Id == id);
        }
        public void Insert(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");

            entities.Add(entity);
            _context.SaveChanges();
        }
        public void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _context.Update(entity);
        }
        public void Delete(Guid id)
        {
            if (id == null) throw new ArgumentNullException("entity");

            T entity = entities.SingleOrDefault(s => s.Id == id);
            entities.Remove(entity);
            _context.SaveChanges();
        }
    }
}
