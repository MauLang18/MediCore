using AutoMapper;
using MediCore.Application.Dtos.Analysis.Response;
using MediCore.Application.UseCase.UseCase.Analysis.Commands.ChangeStateCommand;
using MediCore.Application.UseCase.UseCase.Analysis.Commands.CreateCommand;
using MediCore.Application.UseCase.UseCase.Analysis.Commands.UpdateCommand;
using MediCore.Domain.Entities;

namespace MediCore.Application.UseCase.Mappings
{
    public class AnalysisMappingProfile : Profile
    {
        public AnalysisMappingProfile()
        {
            CreateMap<Analysis, GetAllAnalysisResponseDto>()
                .ForMember(x => x.StateAnalysis, x => x.MapFrom(y => y.State == 1 ? "ACTIVO" : "INACTIVO"))
                .ReverseMap();

            CreateMap<Analysis, GetAnalysisByIdResponseDto>()
                .ReverseMap();

            CreateMap<CreateAnalysisCommand, Analysis>();
            CreateMap<UpdateAnalysisCommand, Analysis>();
            CreateMap<ChangeStateAnalysisCommand, Analysis>();
        }
    }
}
