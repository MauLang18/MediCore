using MediatR;
using MediCore.Application.UseCase.UseCase.Exam.Queries.GetAllQuery;
using MediCore.Application.UseCase.UseCase.Exam.Queries.GetByIdQuery;
using Microsoft.AspNetCore.Mvc;

namespace MediCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ExamController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ListExams()
        {
            var response = await _mediator.Send(new GetAllExamQuery());

            return Ok(response);
        }

        [HttpGet("{examId:int}")]
        public async Task<IActionResult> ExamById(int examId)
        {
            var response = await _mediator.Send(new GetExamByIdQuery() { ExamId = examId});

            return Ok(response);
        }
    }
}
