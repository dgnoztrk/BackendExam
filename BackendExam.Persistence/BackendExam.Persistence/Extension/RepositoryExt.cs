using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BackendExam.Persistence.Extension
{
    public static class RepositoryExt
    {
        public static IQueryable<TEntity> IncludeMultiple<TEntity>(this IQueryable<TEntity> query, params Expression<Func<TEntity, object>>[] includes) where TEntity : class
        {
            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }

            return query;
        }

        public static IEnumerable<TEntity> ListAll<TEntity>(this IQueryable<TEntity> entities, Expression<Func<TEntity, bool>> predicate = null) where TEntity : class
        {
            return predicate == null ? entities.AsNoTracking().ToList() : entities.Where(predicate).AsNoTracking().ToList();
        }
    }
}
