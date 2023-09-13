using MediatR;
using MediCore.Application.Dtos.Exam.Response;
using MediCore.Application.Interface.Interface;
using MediCore.Application.UseCase.Commons.Bases;
using MediCore.Utilities.Constants;

namespace MediCore.Application.UseCase.UseCase.Exam.Queries.GetAllQuery
{
    public class GetAllExamHandle : IRequestHandler<GetAllExamQuery, BaseResponse<IEnumerable<GetAllExamResponseDto>>>
    {
        private readonly IExamRepository _examRepository;

        public GetAllExamHandle(IExamRepository examRepository)
        {
            _examRepository = examRepository;
        }

        public async Task<BaseResponse<IEnumerable<GetAllExamResponseDto>>> Handle(GetAllExamQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<IEnumerable<GetAllExamResponseDto>>();

            try
            {
                var exams = await _examRepository.GetAllExams(SP.uspExamList);

                if(exams is not null)
                {
                    response.IsSuccess = true;
                    response.Data = exams;
                    response.Message = GlobalMessage.MESSAGE_QUERY;
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
