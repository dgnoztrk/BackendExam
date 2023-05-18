namespace BackendExam.Application.Concrete
{
    public class DailySalary : Payrolls
    {
        private readonly int oneDayWorkTime;
        private readonly int calculateSalaryType;

        public DailySalary(int oneDayWorkTime, int calculateSalaryType)
        {
            this.oneDayWorkTime = oneDayWorkTime;
            this.calculateSalaryType = calculateSalaryType;
        }

        public override decimal CalculateSalary(decimal salary, double workedHours)
        {
            return (salary / calculateSalaryType) * (decimal)(workedHours / oneDayWorkTime);
        }
    }
}
