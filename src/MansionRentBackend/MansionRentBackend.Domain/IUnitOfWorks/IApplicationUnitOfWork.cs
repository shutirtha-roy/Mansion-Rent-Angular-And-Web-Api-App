using MansionRentBackend.Domain.Repositories;

namespace MansionRentBackend.Domain.IUnitOfWorks
{
    public interface IApplicationUnitOfWork : IUnitOfWork
    {
        IMansionRepository Mansions { get; }
        IUserRepository Users { get; }
    }
}