using MediatR;
using MediCore.Application.UseCase.Commons.Bases;

namespace MediCore.Application.UseCase.UseCase.Analysis.Commands.ChangeStateCommand
{
    public class ChangeStateAnalysisCommand : IRequest<BaseResponse<bool>>
    {
        public int AnalysisId { get; set; } 
        public int State { get; set; }
    }
}
