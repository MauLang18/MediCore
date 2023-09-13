using AutoMapper;
using MediatR;
using MediCore.Application.Interface.Interface;
using MediCore.Application.UseCase.Commons.Bases;
using Entity = MediCore.Domain.Entities;

namespace MediCore.Application.UseCase.UseCase.Analysis.Commands.CreateCommand
{
    public class CreateAnalysisHandler : IRequestHandler<CreateAnalysisCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateAnalysisHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<bool>> Handle(CreateAnalysisCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                var analysis = _mapper.Map<Entity.Analysis>(request);
                var parameters = new { analysis.Name };
                response.Data = await _unitOfWork.Analysis.ExecAsync("uspAnalysisRegister", parameters);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Se registró correctamente.";
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
