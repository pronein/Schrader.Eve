using Schrader.Eve.Models.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Schrader.Eve.Models.Repositories
{
    public class Repository<TEntity, TId> : IRepository<TEntity, TId>
        where TEntity : class
    {
        private DbContext _context;
        private DbSet<TEntity> _entitySet;

        public Repository(DbContext context)
        {
            _context = context;

            // TODO: should be a try...catch here to catch whatever exception is thrown
            //when the DbSet doesn't exist in the DbContext
            _entitySet = _context.Set<TEntity>();
        }

        public virtual void Insert(TEntity entity)
        {
            _entitySet.Add(entity);
        }

        public virtual TEntity GetById(TId id)
        {
            return _entitySet.Find(id);
        }

        public virtual IEnumerable<TEntity> GetFiltered(System.Linq.Expressions.Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderby = null, string includes = "")
        {
            IQueryable<TEntity> results = _entitySet;

            if (filter != null)
                results = results.Where(filter);

            string[] properties = includes.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string property in properties)
                results = results.Include(property);

            if (orderby != null)
                return orderby(results).ToList();

            return results.ToList();
        }

        public virtual void Update(TEntity entity)
        {
            // TODO: Determine if this action works with a member that
            //is already part of the context.
            _entitySet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TId id)
        {
            TEntity entity = GetById(id);

            if (entity != null)
                _entitySet.Remove(entity);
        }

        public void Delete(TEntity entity)
        {
            _entitySet.Remove(entity);
        }
    }
}