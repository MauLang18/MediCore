using Dapper;
using MediCore.Application.Dtos.Exam.Response;
using MediCore.Application.Interface.Interface;
using MediCore.Persistence.Context;
using System.Data;

namespace MediCore.Persistence.Repositories
{
    public class ExamRepository : IExamRepository
    {
        private readonly ApplicationDbContext _context;

        public ExamRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetAllExamResponseDto>> GetAllExams(string storedProcedure)
        {
            using var connection = _context.CreateConnection;
            var exams = await connection.QueryAsync<GetAllExamResponseDto>(storedProcedure, commandType: CommandType.StoredProcedure);
            return exams;
        }
    }
}
