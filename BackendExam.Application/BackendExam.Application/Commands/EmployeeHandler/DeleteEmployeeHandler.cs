using AutoMapper;
using BackendExam.Application.Shared;
using BackendExam.ApplicationContract.Dto;
using BackendExam.Domain.Entities;
using BackendExam.Persistence.Abstract;
using MediatR;

namespace BackendExam.Application.Commands.EmployeeHandler
{
    public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeCommand, Response<EmployeeDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteEmployeeHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<EmployeeDto>> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Employee find = await _unitOfWork.EmployeeRepository.FindByIdAsync(request.Id);

                if (find == null)
                    return new Response<EmployeeDto>(false, "Çalışan bilgisine ulaşılamadı");

                _unitOfWork.EmployeeRepository.Delete(find);

                await _unitOfWork.SaveAsync();

                return new Response<EmployeeDto>(true, _mapper.Map<EmployeeDto>(find));

            }
            catch (Exception ex)
            {
                return new Response<EmployeeDto>(false, ex.Message);
            }
        }
    }
}
