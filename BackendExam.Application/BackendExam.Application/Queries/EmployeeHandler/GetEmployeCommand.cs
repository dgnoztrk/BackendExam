using BackendExam.Application.Shared;
using BackendExam.ApplicationContract.Dto;
using MediatR;

namespace BackendExam.Application.Queries.EmployeeHandler
{
    public class GetEmployeCommand : IRequest<Response<IEnumerable<EmployeeDto>>>
    {
        public int? Id { get; set; }
        public GetEmployeCommand(int? id)
        {
            Id = id;
        }
    }
}
