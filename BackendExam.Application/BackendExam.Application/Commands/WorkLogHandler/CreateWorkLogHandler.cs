using AutoMapper;
using BackendExam.Application.Shared;
using BackendExam.ApplicationContract.Dto;
using BackendExam.Domain.Entities;
using BackendExam.Persistence.Abstract;
using MediatR;

namespace BackendExam.Application.Commands.WorkLogHandler
{
    public class CreateWorkLogHandler : IRequestHandler<CreateWorkLogCommand, Response<WorkLogDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateWorkLogHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<WorkLogDto>> Handle(CreateWorkLogCommand request, CancellationToken cancellationToken)
        {
			try
			{
                var entity = _mapper.Map<WorkLog>(request.Model);

                await _unitOfWork.WorkLogRepository.InsertAsync(entity);

                await _unitOfWork.SaveAsync();

                return new Response<WorkLogDto>(true, _mapper.Map<WorkLogDto>(request.Model));

			}
			catch (Exception ex)
			{
                return new Response<WorkLogDto>(false, ex.Message);
			}
        }
    }
}
