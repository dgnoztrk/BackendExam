namespace BackendExam.Application.Concrete
{
    public class ConstSalary : Payrolls
    {
        public override decimal CalculateSalary(decimal salary, double workedHours)
        {
            return salary;
        }
    }
}
