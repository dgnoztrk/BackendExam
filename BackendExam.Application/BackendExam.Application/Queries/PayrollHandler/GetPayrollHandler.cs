using AutoMapper;
using BackendExam.Application.Concrete;
using BackendExam.Application.Shared;
using BackendExam.ApplicationContract.Dto;
using BackendExam.ApplicationContract.Enums;
using BackendExam.Domain.Entities;
using BackendExam.Persistence.Abstract;
using MediatR;
using Microsoft.Extensions.Configuration;
using System.Linq.Expressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BackendExam.Application.Queries.PayrollHandler
{
    public class GetPayrollHandler : IRequestHandler<GetPayrollCommand, Response<IEnumerable<PayrollDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public GetPayrollHandler(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<Response<IEnumerable<PayrollDto>>> Handle(GetPayrollCommand request, CancellationToken cancellationToken)
        {
            try
            {

                int oneDayWorkTime = Int32.Parse(_configuration["Settings:OneDayWorkTime"].ToString());
                int calculateSalaryType = Int32.Parse(_configuration["Settings:CalculateSalaryType"].ToString());

                Expression<Func<Employee, bool>> expression = null;

                if(request.Id != null)
                {
                    expression = w => w.Id == request.Id;
                }

                var employeeList = _unitOfWork.EmployeeRepository.List(expression);

                var firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

                List<PayrollDto> resultList = new();

                foreach (var employee in employeeList)
                {
                    var workLogList = _unitOfWork.WorkLogRepository.List(w => w.EmployeeId == employee.Id && (w.StartDate >= firstDayOfMonth && w.EndDate <= lastDayOfMonth));

                    double calculatedTotalHours = workLogList.Select(s => (s.EndDate - s.StartDate).TotalHours).Sum();

                    Payrolls payrolls = employee.WorkType switch
                    {
                        eWorkType.ConstSalary => new ConstSalary(),
                        eWorkType.DailySalary => new DailySalary(oneDayWorkTime, calculateSalaryType),
                        eWorkType.ConstSalaryAndOvertime => new ConstSalaryAndOvertime(oneDayWorkTime, calculateSalaryType),
                        _ => new Payrolls()
                    };
                    
                    resultList.Add(new PayrollDto
                    {
                        EmployeeId = employee.Id,
                        Name = employee.Name,
                        Surname = employee.Surname,
                        IdentityNo = employee.IdentityNo,
                        Salary  = employee.Salary,
                        WorkType = employee.WorkType,
                        CalculatedSalary = payrolls.CalculateSalary(employee.Salary, calculatedTotalHours),
                        CalculatedWorkTime = calculatedTotalHours
                    });
                }

                return new Response<IEnumerable<PayrollDto>>(true, resultList);
            }
            catch (Exception ex)
            {
                return new Response<IEnumerable<PayrollDto>>(false, ex.Message);
            }
        }
    }
}
