using BackendExam.ApplicationContract.Enums;

namespace BackendExam.ApplicationContract.Dto
{
    public class PayrollDto
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string IdentityNo { get; set; }
        public decimal Salary { get; set; }
        public eWorkType WorkType { get; set; }
        public double CalculatedWorkTime { get; set; }
        public decimal CalculatedSalary { get; set; }
    }
}
