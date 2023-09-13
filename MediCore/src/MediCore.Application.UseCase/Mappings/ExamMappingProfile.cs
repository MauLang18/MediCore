using AutoMapper;
using MediCore.Application.Dtos.Exam.Response;
using MediCore.Domain.Entities;

namespace MediCore.Application.UseCase.Mappings
{
    public class ExamMappingProfile : Profile
    {
        public ExamMappingProfile()
        {
            CreateMap<Exam, GetExamByIdResponseDto>()
                .ReverseMap();
        }
    }
}
