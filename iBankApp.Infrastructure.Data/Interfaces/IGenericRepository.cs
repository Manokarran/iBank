using System;
using System.Linq;
using System.Linq.Expressions;

namespace iBankApp.Interfaces.Data
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        // Data retrieval Operations

        #region Data Retrieval

        /// <summary>
        ///     Get all.
        /// </summary>
        /// <returns>IQueryable TEntity</returns>
        IQueryable<TEntity> Get();

        /// <summary>
        ///     Gets by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>TEntity</returns>
        TEntity Get(object id);

        /// <summary>
        ///     Gets the items.
        /// </summary>
        /// <param name="expression">The predicate.</param>
        /// <param name="includes">The includes.</param>
        /// <returns>IQueryable TEntity</returns>
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> expression,
            params Expression<Func<TEntity, object>>[] includes);

        /// <summary>
        ///     Gets all read only.
        /// </summary>
        /// <returns>IQueryable TEntity</returns>
        IQueryable<TEntity> GetReadOnly();

        /// <summary>
        ///     Get read only.
        /// </summary>
        /// <param name="expression">The predicate.</param>
        /// <param name="includes">The includes.</param>
        /// <returns>IQueryable TEntity</returns>
        IQueryable<TEntity> GetReadOnly(Expression<Func<TEntity, bool>> expression,
            params Expression<Func<TEntity, object>>[] includes);

        /// <summary>
        ///     Get read only.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IQueryable TEntity</returns>
        IQueryable<TEntity> GetReadOnly(Expression<Func<TEntity, bool>> filter,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, int page = 0, int pageSize = 50);

        #endregion

        // Count Operations

        #region Count

        /// <summary>
        ///     Counts this instance.
        /// </summary>
        /// <returns></returns>
        int Count();

        /// <summary>
        ///     Counts the specified expression.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        int Count(Expression<Func<TEntity, bool>> expression);

        #endregion
    }
}