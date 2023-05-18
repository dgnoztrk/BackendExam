using AutoMapper;
using BackendExam.Application.Shared;
using BackendExam.ApplicationContract.Dto;
using BackendExam.Domain.Entities;
using BackendExam.Persistence.Abstract;
using MediatR;

namespace BackendExam.Application.Commands.EmployeeHandler
{
    public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, Response<EmployeeDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateEmployeeHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<EmployeeDto>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
			try
			{
                var entity = _mapper.Map<Employee>(request.Model);

                await _unitOfWork.EmployeeRepository.InsertAsync(entity);

                await _unitOfWork.SaveAsync();

                return new Response<EmployeeDto>(true, _mapper.Map<EmployeeDto>(request.Model));

			}
			catch (Exception ex)
			{
                return new Response<EmployeeDto>(false, ex.Message);
			}
        }
    }
}
