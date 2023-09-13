using MediCore.Application.Interface.Interface;
using MediCore.Domain.Entities;

namespace MediCore.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IGenericRepository<Analysis> Analysis { get; }
        public IGenericRepository<Exam> Exam { get; }

        public UnitOfWork(IGenericRepository<Analysis> analysis, IGenericRepository<Exam> exam)
        {
            Analysis = analysis;
            Exam = exam;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
