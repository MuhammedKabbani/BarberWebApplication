using Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IRepositoryBase<TEntity,TContext> where TEntity : class, IEntity, new() where TContext : DbContext, new()
    {
        TEntity? Get(object id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> GetAllIncluded(params Expression<System.Func<TEntity, object>>[] includeProperties);
        IEnumerable<TEntity> GetAllIncluded(Expression<Func<TEntity, bool>> predicate, params Expression<System.Func<TEntity, object>>[] includeProperties);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        TEntity? SingleOrDefault(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);

    }
}
