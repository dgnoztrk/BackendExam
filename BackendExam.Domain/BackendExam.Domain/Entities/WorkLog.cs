using BackendExam.Domain.Entities.Base;

namespace BackendExam.Domain.Entities
{
    public class WorkLog : EntityBase
    {
        public virtual int EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
