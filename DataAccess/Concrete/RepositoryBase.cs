using DataAccess.Abstract;
using DataAccess.Context.EFCore;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;

namespace DataAccess.Concrete
{
    public class RepositoryBase<TEntity, TContext> : IRepositoryBase<TEntity, TContext> where TEntity : class, IEntity, new() where TContext : DbContext, new()
    {
        /// <summary>
        /// Add entity to the context
        /// </summary>
        public void Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                context.Set<TEntity>().Add(entity);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Add range of entities to the context
        /// </summary>
        public void AddRange(IEnumerable<TEntity> entities)
        {
            using (var context = new TContext())
            {
                context.Set<TEntity>().AddRange(entities);
                context.SaveChanges();
            }
            
        }

        /// <summary>
        /// Get entity by id
        /// </summary>
        public TEntity? Get(object id)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().Find(id);
            }
        }
        /// <summary>
        /// get single entity based on the predicate
        /// </summary>
        public TEntity? SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(predicate);
            }
        }
        /// <summary>
        /// get single entity based on the predicate with included properties
        /// </summary>
        public TEntity? SingleOrDefault(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return GetAllIncluded(predicate, includeProperties).AsQueryable().SingleOrDefault(predicate);
        }
        /// <summary>
        /// Get all entities
        /// </summary>
        public IEnumerable<TEntity> GetAll()
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().ToList();
            }
        }
        /// <summary>
        /// get all entities based on the predicate
        /// </summary>
        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().Where(predicate).ToList();
            }
        }
        /// <summary>
        /// get all entities with included properties
        /// </summary>
        public IEnumerable<TEntity> GetAllIncluded(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            using (var context = new TContext())
            {
                var query = context.Set<TEntity>().AsQueryable();
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
                return query.ToList();
            }
        }
        /// <summary>
        /// get all entities with included properties based on the predicate
        /// </summary>
        public IEnumerable<TEntity> GetAllIncluded(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            using (var context = new TContext())
            {
                var query = context.Set<TEntity>().Where(predicate);
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
                return query.ToList();
            }
        }


        /// <summary>
        /// Remove entity from the context
        /// </summary>
        public void Remove(TEntity entity)
        {
            using (var context = new TContext())
            {
                context.Set<TEntity>().Remove(entity);
            }
        }
        /// <summary>
        /// Remove range of entities from the context
        /// </summary>
        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            using (var context = new TContext())
            {
                context.Set<TEntity>().RemoveRange(entities);
            }
        }

        /// <summary>
        /// check if there is any entity in the context
        /// </summary>
        public bool Any()
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().Any();
            }
        }

        /// <summary>
        /// check if there is any entity in the context based on the predicate
        /// </summary>
        public bool Any(Expression<Func<TEntity, bool>> predicate)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().Any(predicate);
            }
        }
        /// <summary>
        /// count all entities in the context
        /// </summary>
        public int Count()
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().Count();
            }
        }
        /// <summary>
        /// count all entities in the context based on the predicate
        /// </summary>
        public int Count(Expression<Func<TEntity, bool>> predicate)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().Count(predicate);
            }
        }


    }
}
