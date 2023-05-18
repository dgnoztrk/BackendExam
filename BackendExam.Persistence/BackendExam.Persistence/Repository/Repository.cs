using BackendExam.Domain.Entities;
using BackendExam.Domain.Entities.Base;
using BackendExam.Persistence.Abstract;
using BackendExam.Persistence.Context;
using BackendExam.Persistence.Extension;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BackendExam.Persistence.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : EntityBase
    {
        public DbSet<TEntity> _dbSet { get; set; }
        public readonly SqlServerDbContext _dbContext;

        public Repository(SqlServerDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }

        public void Delete(TEntity model)
        {
            _dbSet.Remove(model);
        }

        /// <summary>
        /// Bu metod ile alınan entity'ler delete edilemez, tracking edilmeden alınan entityler delete edilebilir
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TEntity> FindByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task InsertAsync(TEntity model)
        {
            await _dbSet.AddAsync(model);
        }

        public IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includes)
        {
            return RepositoryExt.IncludeMultiple(_dbSet.AsQueryable(), includes);
        }        

        public IEnumerable<TEntity> List(Expression<Func<TEntity, bool>> predicate = null)
        {
            return predicate == null ? _dbSet.AsNoTracking().ToList() : _dbSet.Where(predicate).AsNoTracking().ToList();
        }

        public void Update(TEntity model)
        {
            _dbSet.Update(model);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _dbSet.Where(w => w.Id == id).ExecuteDeleteAsync();
        }
    }    
}
