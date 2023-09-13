using MediatR;
using MediCore.Application.Dtos.Exam.Response;
using MediCore.Application.UseCase.Commons.Bases;

namespace MediCore.Application.UseCase.UseCase.Exam.Queries.GetAllQuery
{
    public class GetAllExamQuery : IRequest<BaseResponse<IEnumerable<GetAllExamResponseDto>>>
    {
    }
}
