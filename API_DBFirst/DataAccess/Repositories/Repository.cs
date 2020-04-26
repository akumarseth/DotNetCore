using DataAccess.DataModel;
using DataAccess.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly API_DBFirstDBContext Context;

        public Repository(API_DBFirstDBContext context)
        {
            Context = context;
        }

        /// <summary>
        /// Adds an entity into the repository
        /// </summary>
        public virtual void Add(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public virtual void Update(T entity)
        {
            Context.Set<T>().Update(entity);
        }

        public async void AddAsync(T entity)
        {
            await Context.Set<T>().AddAsync(entity);
        }

        /// <summary>
        /// Adds a range of entities into the repository
        /// </summary>
        public virtual void AddRange(IEnumerable<T> entities)
        {
            Context.Set<T>().AddRange(entities);
        }

        public async void AddRangeAsync(IEnumerable<T> entities)
        {
            await Context.Set<T>().AddRangeAsync(entities);
        }

        /// <summary>
        ///  Attaches an existing entity marked as modified
        /// </summary>
        public virtual void Edit(T entity)
        {
            Context.Set<T>().Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// Performs a search on the repository for the given predicate
        /// and returns a list of matched entities
        /// </summary>
        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().AsNoTracking().Where(predicate);
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await Context.Set<T>().AsNoTracking().Where(predicate).ToListAsync();
        }

        /// <summary>
        /// Finds first element  or returns null from table.
        /// </summary>
        /// <returns>Record.</returns>
        public T First()
        {
            return Context.Set<T>().First();
        }

        public async Task<T> FirstAsync()
        {
            return await Context.Set<T>().FirstAsync();
        }

        /// <summary>
        /// Finds first element or returns null from table.
        /// </summary>
        /// <returns>Record.</returns>
        public T FirstOrDefault()
        {
            return Context.Set<T>().FirstOrDefault();
        }

        /// <summary>
        /// Finds first element or returns null from table based on Expression passed in.
        /// </summary>
        /// <returns>Record.</returns>
        public T FirstOrDefault(Expression<Func<T, bool>> predicate) => FirstOrDefault(predicate, false);

        /// <summary>
        /// Finds first element or returns null from table based on Expression passed in.
        /// </summary>
        /// <returns>Record.</returns>
        public T FirstOrDefault(Expression<Func<T, bool>> predicate, bool local)
        {
            T result = default(T);

            if (predicate != null)
            {
                result = local
                    ? Context.Set<T>().FirstOrDefault(predicate.Compile())
                    : Context.Set<T>().FirstOrDefault(predicate);
            }

            return result;
        }

        public async Task<T> FirstOrDefaultAsync()
        {
            return await Context.Set<T>().FirstOrDefaultAsync();
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await FirstOrDefaultAsync(predicate, false);
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, bool local)
        {
            return await Context.Set<T>().Where(predicate).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Performs a search on the repository for the given predicate
        /// and returns a list of matched entities
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual T Get(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate).FirstOrDefault();
        }

        /// <summary>
        /// Gets all entities in a repository as a list
        /// </summary>
        public virtual IEnumerable<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await Context.Set<T>().Where(predicate).ToListAsync();
        }

        /// <summary>
        /// Finds last element from table.
        /// </summary>
        /// <returns>Record.</returns>
        public T Last()
        {
            return Context.Set<T>().Last();
        }

        public async Task<T> LastAsync()
        {
            return await Context.Set<T>().LastAsync();
        }

        /// <summary>
        /// Finds last element or returns null from table based on Expression passed in.
        /// </summary>
        /// <returns>Record.</returns>
        public T LastOrDefault(Expression<Func<T, bool>> predicate) => LastOrDefault(predicate, false);

        /// <summary>
        /// Finds last element or returns null from table based on Expression passed in.
        /// </summary>
        /// <returns>Record.</returns>
        public T LastOrDefault(Expression<Func<T, bool>> predicate, bool local)
        {
            T result = default(T);

            if (predicate != null)
            {
                result = local
                    ? Context.Set<T>().LastOrDefault(predicate.Compile())
                    : Context.Set<T>().LastOrDefault(predicate);
            }

            return result;
        }

        /// <summary>
        /// Finds last element or returns null from table.
        /// </summary>
        /// <returns>Record.</returns>
        public T LastOrDefault()
        {
            return Context.Set<T>().LastOrDefault();
        }

        public async Task<T> LastOrDefaultAsync()
        {
            return await Context.Set<T>().LastOrDefaultAsync();
        }

        public async Task<T> LastOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await LastOrDefaultAsync(predicate, false);
        }

        public Task<T> LastOrDefaultAsync(Expression<Func<T, bool>> predicate, bool local)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes one given entity from repository
        /// </summary>
        public virtual void Remove(T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        /// <summary>
        /// Removes a range of given entities from the repository
        /// </summary>
        public virtual void RemoveRange(IEnumerable<T> entities)
        {
            Context.Set<T>().RemoveRange(entities);
        }
    }
}
