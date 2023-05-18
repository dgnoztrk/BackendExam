using BackendExam.Application.Shared;
using BackendExam.ApplicationContract.Dto;
using MediatR;

namespace BackendExam.Application.Commands.WorkLogHandler
{
    public class DeleteWorkLogCommand : IRequest<Response<WorkLogDto>>
    {
        public int Id { get; }

        public DeleteWorkLogCommand(int id)
        {
            Id = id;
        }
    }
}
