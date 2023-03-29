using MansionRentBackend.Application.Repositories;

namespace MansionRentBackend.Application.UnitOfWorks
{
    public interface IApplicationUnitOfWork : IUnitOfWork
    {
        IMansionRepository Mansions { get; }
        IUserRepository Users { get; }
    }
}