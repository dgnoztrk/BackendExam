using AutoMapper;
using BackendExam.Application.Shared;
using BackendExam.ApplicationContract.Dto;
using BackendExam.Domain.Entities;
using BackendExam.Persistence.Abstract;
using BackendExam.Persistence.Repository;
using MediatR;
using System.Linq.Expressions;

namespace BackendExam.Application.Queries.WorkLogHandler
{
    public class GetWorkLogHandler : IRequestHandler<GetWorkLogCommand, Response<IEnumerable<WorkLogDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetWorkLogHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<Response<IEnumerable<WorkLogDto>>> Handle(GetWorkLogCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<WorkLog, bool>> expression = null;

                if (request.Id.HasValue)
                {
                    expression = w => w.Id == request.Id;
                }

                IEnumerable<WorkLogDto> result = _mapper.Map<IEnumerable<WorkLogDto>>(_unitOfWork.WorkLogRepository.Include(f => f.Employee).ListAll(expression));

                return Task.FromResult(new Response<IEnumerable<WorkLogDto>>(true, result));
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Response<IEnumerable<WorkLogDto>>(false, ex.Message + " -> " + ex.StackTrace));
            }
        }
    }
}
