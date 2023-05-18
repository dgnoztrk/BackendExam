using BackendExam.Domain.Entities.Base;
using BackendExam.Persistence.Repository;

namespace BackendExam.Persistence.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : EntityBase;

        EmployeeRepository EmployeeRepository { get; }
        WorkLogRepository WorkLogRepository { get; }

        Task SaveAsync();
    }
}
