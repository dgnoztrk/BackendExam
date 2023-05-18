using BackendExam.Application.Shared;
using BackendExam.ApplicationContract.Dto;
using MediatR;

namespace BackendExam.Application.Commands.EmployeeHandler
{
    public class UpdateEmployeeCommand : IRequest<Response<EmployeeDto>>
    {
        public CreateUpdateEmployeeDto Model { get; set; }
        public int Id { get; set; }
        public UpdateEmployeeCommand(int id, CreateUpdateEmployeeDto model)
        {
            Id = id;
            Model = model;
        }
    }
}
