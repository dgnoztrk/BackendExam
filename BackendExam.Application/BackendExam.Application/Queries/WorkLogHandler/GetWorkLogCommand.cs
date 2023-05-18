using BackendExam.Application.Shared;
using BackendExam.ApplicationContract.Dto;
using MediatR;

namespace BackendExam.Application.Queries.WorkLogHandler
{
    public class GetWorkLogCommand : IRequest<Response<IEnumerable<WorkLogDto>>>
    {
        public int? Id { get; set; }
        public GetWorkLogCommand(int? id)
        {
            Id = id;
        }
    }
}
