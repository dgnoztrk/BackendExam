using BackendExam.Application.Shared;
using BackendExam.ApplicationContract.Dto;
using MediatR;

namespace BackendExam.Application.Commands.EmployeeHandler
{
    public class CreateEmployeeCommand : IRequest<Response<EmployeeDto>>
    {
        public CreateUpdateEmployeeDto Model { get; set; }
        public CreateEmployeeCommand(CreateUpdateEmployeeDto model)
        {

            Model = model;
        }
    }
}
