namespace BackendExam.Application.Concrete
{
    public class ConstSalaryAndOvertime : Payrolls
    {
        private readonly int oneDayWorkTime;
        private readonly int calculateSalaryType;

        public ConstSalaryAndOvertime(int oneDayWorkTime, int calculateSalaryType)
        {
            this.oneDayWorkTime = oneDayWorkTime;
            this.calculateSalaryType = calculateSalaryType;
        }

        public override decimal CalculateSalary(decimal salary, double workedHours)
        {
            return salary + ((decimal)workedHours * ((salary / calculateSalaryType) / oneDayWorkTime));
        }
    }
}
