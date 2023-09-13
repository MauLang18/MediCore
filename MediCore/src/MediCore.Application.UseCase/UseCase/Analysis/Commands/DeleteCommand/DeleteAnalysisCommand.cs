using MediatR;
using MediCore.Application.UseCase.Commons.Bases;

namespace MediCore.Application.UseCase.UseCase.Analysis.Commands.DeleteCommand
{
    public class DeleteAnalysisCommand : IRequest<BaseResponse<bool>>
    {
        public int AnalysisId { get; set; }
    }
}
