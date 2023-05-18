using BackendExam.Domain.Entities;
using BackendExam.Persistence.Context;

namespace BackendExam.Persistence.Repository
{
    public class EmployeeRepository : Repository<Employee>
    {
        public EmployeeRepository(SqlServerDbContext dbContext) : base(dbContext)
        {
        }
    }
}
