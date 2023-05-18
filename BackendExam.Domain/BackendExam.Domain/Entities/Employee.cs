using BackendExam.ApplicationContract.Enums;
using BackendExam.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace BackendExam.Domain.Entities
{
    public class Employee : EntityBase
    {
        public string IdentityNo { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public decimal Salary { get; set; }
        public eWorkType WorkType { get; set; }

        public virtual ICollection<WorkLog> WorkLogs { get; set; }
    }
}
