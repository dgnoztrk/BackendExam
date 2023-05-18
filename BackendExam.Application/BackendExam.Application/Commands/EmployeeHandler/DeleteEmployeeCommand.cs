using BackendExam.Application.Shared;
using BackendExam.ApplicationContract.Dto;
using MediatR;

namespace BackendExam.Application.Commands.EmployeeHandler
{
    public class DeleteEmployeeCommand : IRequest<Response<EmployeeDto>>
    {
        public int Id { get; }

        public DeleteEmployeeCommand(int id)
        {
            Id = id;
        }
    }
}
