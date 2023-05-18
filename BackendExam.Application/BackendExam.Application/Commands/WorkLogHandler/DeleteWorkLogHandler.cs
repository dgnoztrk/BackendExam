using AutoMapper;
using BackendExam.Application.Commands.WorkLogHandler;
using BackendExam.Application.Shared;
using BackendExam.ApplicationContract.Dto;
using BackendExam.Domain.Entities;
using BackendExam.Persistence.Abstract;
using MediatR;

namespace BackendExam.Application.Commands.WorkLogHandler
{
    public class DeleteWorkLogHandler : IRequestHandler<DeleteWorkLogCommand, Response<WorkLogDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteWorkLogHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<WorkLogDto>> Handle(DeleteWorkLogCommand request, CancellationToken cancellationToken)
        {
            try
            {
                WorkLog find = await _unitOfWork.WorkLogRepository.FindByIdAsync(request.Id);

                if (find == null)
                    return new Response<WorkLogDto>(false, "Kayıt bulunamadı");

                _unitOfWork.WorkLogRepository.Delete(find);

                await _unitOfWork.SaveAsync();

                return new Response<WorkLogDto>(true, _mapper.Map<WorkLogDto>(find));

            }
            catch (Exception ex)
            {
                return new Response<WorkLogDto>(false, ex.Message);
            }
        }
    }
}
