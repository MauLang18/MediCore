using MediatR;
using MediCore.Application.UseCase.Commons.Bases;

namespace MediCore.Application.UseCase.UseCase.Analysis.Commands.CreateCommand
{
    public class CreateAnalysisCommand : IRequest<BaseResponse<bool>>
    {
        public string? Name { get; set; }
    }
}
