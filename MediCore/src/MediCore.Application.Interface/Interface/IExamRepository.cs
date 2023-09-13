using MediCore.Application.Dtos.Exam.Response;

namespace MediCore.Application.Interface.Interface
{
    public interface IExamRepository
    {
        Task<IEnumerable<GetAllExamResponseDto>> GetAllExams(string storedProcedure);
    }
}
