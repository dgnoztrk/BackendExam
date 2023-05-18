using AutoMapper;
using BackendExam.Application.Shared;
using BackendExam.ApplicationContract.Dto;
using BackendExam.Domain.Entities;
using BackendExam.Persistence.Abstract;
using MediatR;
using System.Linq.Expressions;

namespace BackendExam.Application.Queries.EmployeeHandler
{
    public class GetEmployeeHandler : IRequestHandler<GetEmployeCommand, Response<IEnumerable<EmployeeDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetEmployeeHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<Response<IEnumerable<EmployeeDto>>> Handle(GetEmployeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<Employee, bool>> expression = null;

                if (request.Id.HasValue)
                {
                    expression = w => w.Id == request.Id;
                }

                IEnumerable<EmployeeDto> result = _mapper.Map<IEnumerable<EmployeeDto>>(_unitOfWork.EmployeeRepository.List(expression));

                return Task.FromResult(new Response<IEnumerable<EmployeeDto>>(true, result));
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Response<IEnumerable<EmployeeDto>>(false, ex.Message + " -> " + ex.StackTrace));
            }
        }
    }
}
