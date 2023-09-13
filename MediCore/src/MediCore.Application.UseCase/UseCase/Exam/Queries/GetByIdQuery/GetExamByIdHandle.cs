using AutoMapper;
using MediatR;
using MediCore.Application.Dtos.Exam.Response;
using MediCore.Application.Interface.Interface;
using MediCore.Application.UseCase.Commons.Bases;
using MediCore.Utilities.Constants;

namespace MediCore.Application.UseCase.UseCase.Exam.Queries.GetByIdQuery
{
    public class GetExamByIdHandle : IRequestHandler<GetExamByIdQuery, BaseResponse<GetExamByIdResponseDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetExamByIdHandle(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<GetExamByIdResponseDto>> Handle(GetExamByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<GetExamByIdResponseDto>();

            try
            {
                var exam = await _unitOfWork.Exam.GetByIdAsync(SP.uspExamById, request);

                if(exam is null)
                {
                    response.IsSuccess = false;
                    response.Message = GlobalMessage.MESSAGE_QUERY_EMPTY;
                    return response;
                }

                response.IsSuccess = true;
                response.Data = _mapper.Map<GetExamByIdResponseDto>(exam);
                response.Message = GlobalMessage.MESSAGE_QUERY;
            }
            catch(Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
