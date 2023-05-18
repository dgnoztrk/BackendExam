using BackendExam.Domain.Entities;
using BackendExam.Persistence.Context;

namespace BackendExam.Persistence.Repository
{
    public class WorkLogRepository : Repository<WorkLog>
    {
        public WorkLogRepository(SqlServerDbContext dbContext) : base(dbContext)
        {
        }
    }
}
