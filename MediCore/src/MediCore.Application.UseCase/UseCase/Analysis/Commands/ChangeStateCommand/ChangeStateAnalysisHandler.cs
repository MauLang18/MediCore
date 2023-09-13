﻿using AutoMapper;
using MediatR;
using MediCore.Application.Interface.Interface;
using MediCore.Application.UseCase.Commons.Bases;
using Entity = MediCore.Domain.Entities;

namespace MediCore.Application.UseCase.UseCase.Analysis.Commands.ChangeStateCommand
{
    public class ChangeStateAnalysisHandler : IRequestHandler<ChangeStateAnalysisCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ChangeStateAnalysisHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(ChangeStateAnalysisCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                var analysis = _mapper.Map<Entity.Analysis>(request);
                var parameters = new { analysis.AnalysisId, analysis.State };
                response.Data = await _unitOfWork.Analysis.ExecAsync("uspAnalysisChangeState", parameters);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Se actualizó el estado correctamente!!!";
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
