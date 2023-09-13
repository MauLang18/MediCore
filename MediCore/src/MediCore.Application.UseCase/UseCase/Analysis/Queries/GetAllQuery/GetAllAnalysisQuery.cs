using MediatR;
using MediCore.Application.Dtos.Analysis.Response;
using MediCore.Application.UseCase.Commons.Bases;

namespace MediCore.Application.UseCase.UseCase.Analysis.Queries.GetAllQuery
{
    public class GetAllAnalysisQuery : IRequest<BaseResponse<IEnumerable<GetAllAnalysisResponseDto>>> { }
}
