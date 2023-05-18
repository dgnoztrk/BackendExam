using System.ComponentModel;

namespace BackendExam.ApplicationContract.Enums
{
    public enum eWorkType:byte
    {
        [Description("Sabit Maaş")]
        ConstSalary = 0,
        [Description("Günlük Maaş")]
        DailySalary = 1,
        [Description("Sabit Maaş + Mesai")]
        ConstSalaryAndOvertime = 2
    }
}
