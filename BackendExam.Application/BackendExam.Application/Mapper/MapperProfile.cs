using AutoMapper;
using BackendExam.ApplicationContract.Dto;
using BackendExam.Domain.Entities;

namespace BackendExam.Application.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CreateUpdateEmployeeDto, Employee>().ReverseMap();
            CreateMap<CreateUpdateEmployeeDto, EmployeeDto>().ReverseMap();
            CreateMap<EmployeeDto, Employee>().ReverseMap();

            CreateMap<CreateUpdateWorkLogDto, WorkLog>().ReverseMap();
            CreateMap<CreateUpdateWorkLogDto, WorkLogDto>().ReverseMap();
            CreateMap<WorkLogDto, WorkLog>().ReverseMap();
        }
    }
}
