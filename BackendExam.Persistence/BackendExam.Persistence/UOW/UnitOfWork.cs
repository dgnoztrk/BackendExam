using BackendExam.Domain.Entities.Base;
using BackendExam.Persistence.Abstract;
using BackendExam.Persistence.Context;
using BackendExam.Persistence.Repository;

namespace BackendExam.Persistence.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SqlServerDbContext _context;
        private bool _disposed;
        private Dictionary<Type, object> _repositories;
        private EmployeeRepository _employeeRepository;
        private WorkLogRepository _workLogRepository;

        public UnitOfWork(SqlServerDbContext context)
        {
            _context = context;
            _repositories = new Dictionary<Type, object>();
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : EntityBase
        {
            if (_repositories.ContainsKey(typeof(TEntity)))
            {
                return (IRepository<TEntity>)_repositories[typeof(TEntity)];
            }

            var repository = new Repository<TEntity>(_context);

            _repositories.Add(typeof(TEntity), repository);

            return repository;
        }

        public EmployeeRepository EmployeeRepository
        {
            get { return _employeeRepository ??= new EmployeeRepository(_context); }
        }

        public WorkLogRepository WorkLogRepository
        {
            get { return _workLogRepository ??= new WorkLogRepository(_context); }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
