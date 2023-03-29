using MansionRentBackend.Application.Repositories;

namespace MansionRentBackend.Application.UnitOfWorks
{
    public interface IApplicationUnitOfWork : IUnitOfWork
    {
        IVillaRepository Villas { get; }
        IUserRepository Users { get; }
    }
}