using MediatR;
using MediCore.Application.Dtos.Analysis.Response;
using MediCore.Application.UseCase.Commons.Bases;

namespace MediCore.Application.UseCase.UseCase.Analysis.Queries.GetByIdQuery
{
    public class GetAnalysisByIdQuery : IRequest<BaseResponse<GetAnalysisByIdResponseDto>>
    {
        public int AnalysisId { get; set; }
    }
}
