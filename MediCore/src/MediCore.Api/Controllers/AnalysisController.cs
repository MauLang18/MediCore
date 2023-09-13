using MediatR;
using MediCore.Application.UseCase.UseCase.Analysis.Commands.ChangeStateCommand;
using MediCore.Application.UseCase.UseCase.Analysis.Commands.CreateCommand;
using MediCore.Application.UseCase.UseCase.Analysis.Commands.DeleteCommand;
using MediCore.Application.UseCase.UseCase.Analysis.Commands.UpdateCommand;
using MediCore.Application.UseCase.UseCase.Analysis.Queries.GetAllQuery;
using MediCore.Application.UseCase.UseCase.Analysis.Queries.GetByIdQuery;
using Microsoft.AspNetCore.Mvc;

namespace MediCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalysisController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AnalysisController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ListAnalysis()
        {
            var response = await _mediator.Send(new GetAllAnalysisQuery());

            return Ok(response);
        }

        [HttpGet("{analysisId:int}")]
        public async Task<IActionResult> AnalysisById(int analysisId)
        {
            var response = await _mediator.Send(new GetAnalysisByIdQuery() { AnalysisId = analysisId });

            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAnalysis([FromBody] CreateAnalysisCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> EditAnalysis([FromBody] UpdateAnalysisCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpDelete("Remove/{analysisId:int}")]
        public async Task<IActionResult> RemoveAnalysis(int analysisId)
        {
            var response = await _mediator.Send(new DeleteAnalysisCommand() { AnalysisId = analysisId });

            return Ok(response);
        }

        [HttpPut("ChangeState")]
        public async Task<IActionResult> ChangeStateAnalysis([FromBody] ChangeStateAnalysisCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }
    }
}
