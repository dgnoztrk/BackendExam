using BackendExam.Application.Shared;
using BackendExam.ApplicationContract.Dto;
using MediatR;

namespace BackendExam.Application.Commands.WorkLogHandler
{
    public class CreateWorkLogCommand : IRequest<Response<WorkLogDto>>
    {
        public CreateUpdateWorkLogDto Model { get; set; }
        public CreateWorkLogCommand(CreateUpdateWorkLogDto model)
        {
            Model = model;
        }
    }
}
