using BackendExam.Application.Shared;
using BackendExam.ApplicationContract.Dto;
using MediatR;

namespace BackendExam.Application.Commands.WorkLogHandler
{
    public class UpdateWorkLogCommand : IRequest<Response<WorkLogDto>>
    {
        public CreateUpdateWorkLogDto Model { get; set; }
        public int Id { get; set; }
        public UpdateWorkLogCommand(int id, CreateUpdateWorkLogDto model)
        {
            Id = id;
            Model = model;
        }
    }
}
