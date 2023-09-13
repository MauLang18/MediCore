using MediCore.Domain.Entities;

namespace MediCore.Application.Interface.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Analysis> Analysis { get; }
    }
}
