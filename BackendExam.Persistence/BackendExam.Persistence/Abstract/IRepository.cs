using BackendExam.Domain.Entities.Base;
using System.Linq.Expressions;

namespace BackendExam.Persistence.Abstract
{
    public interface IRepository<TEntity> where TEntity : EntityBase
    {
        Task<TEntity> FindByIdAsync(int id);
        IEnumerable<TEntity> List(Expression<Func<TEntity, bool>> predicate = null);
        Task InsertAsync(TEntity model);
        void Update(TEntity model);
        void Delete(TEntity model);
        Task DeleteAsync(int id);
        Task SaveChangesAsync();
        IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includes);
    }
}
