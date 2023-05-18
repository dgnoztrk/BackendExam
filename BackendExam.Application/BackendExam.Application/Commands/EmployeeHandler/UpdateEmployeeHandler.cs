using AutoMapper;
using BackendExam.Application.Shared;
using BackendExam.ApplicationContract.Dto;
using BackendExam.Domain.Entities;
using BackendExam.Persistence.Abstract;
using MediatR;

namespace BackendExam.Application.Commands.EmployeeHandler
{
    public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeCommand, Response<EmployeeDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateEmployeeHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<EmployeeDto>> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _mapper.Map<Employee>(request.Model);

                entity.Id = request.Id;

                _unitOfWork.EmployeeRepository.Update(entity);

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
