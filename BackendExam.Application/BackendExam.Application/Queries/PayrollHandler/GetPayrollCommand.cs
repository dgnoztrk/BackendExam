using BackendExam.Application.Shared;
using BackendExam.ApplicationContract.Dto;
using MediatR;

namespace BackendExam.Application.Queries.PayrollHandler
{
    public class GetPayrollCommand : IRequest<Response<IEnumerable<PayrollDto>>>
    {
        public int? Id { get; set; }
        public GetPayrollCommand(int? id)
        {

            Id = id;

        }
    }
}
