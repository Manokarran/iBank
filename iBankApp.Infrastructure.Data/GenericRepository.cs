using iBankApp.Core.Data.Model;
using iBankApp.Interfaces.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace iBankApp.Infrastructure.Data
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> _dbset;

        protected GenericRepository(iBankAppContext dbContext) => _dbset = dbContext.Set<TEntity>();


        // Data retrieval Operations
        #region Data Retrieval

        private IQueryable<TEntity> Query => _dbset;

        public IQueryable<TEntity> Get()
        {
            return Query;
        }

        public TEntity Get(object id)
        {
            return _dbset.Find(id);
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object>>[] navigationProperties)
        {
            var queryable = Query;

            if (navigationProperties != null)
            {
                queryable = navigationProperties.Aggregate(queryable,
                    (current, navigationProperty) => current.Include(navigationProperty));
            }

            return queryable.Where(expression);
        }

        public IQueryable<TEntity> GetReadOnly()
        {
            return Query.AsNoTracking();
        }

        public IQueryable<TEntity> GetReadOnly(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object>>[] navigationProperties)
        {
            var queryable = Query.AsNoTracking();

            if (navigationProperties != null)
            {
                queryable = navigationProperties.Aggregate(queryable,
                    (current, navigationProperty) => current.Include(navigationProperty));
            }

            return queryable.Where(expression);
        }

        public IQueryable<TEntity> GetReadOnly(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,
            int page = 0, int pageSize = 50)
        {
            var query = Query.AsNoTracking();

            if (filter != null)
                query = query.Where(filter);

            query = orderBy(query);

            query = query
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            return query;
        }



        #endregion

        // Count Operations
        #region Count

        public int Count()
        {
            return _dbset.Count();
        }

        public int Count(Expression<Func<TEntity, bool>> expression)
        {
            return expression != null ? _dbset.Where(expression).Count() : Count();
        }

        #endregion
    }
}
