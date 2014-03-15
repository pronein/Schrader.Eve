using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Schrader.Eve.Models.Repositories.Interfaces
{
    public interface IRepository<TEntity,TId> where TEntity : class
    {
        void Insert(TEntity entity);

        TEntity GetById(TId id);
        IEnumerable<TEntity> GetFiltered(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderby = null, string includes = "");
        
        void Update(TEntity entity);

        void Delete(TId id);
        void Delete(TEntity entity);
    }
}
