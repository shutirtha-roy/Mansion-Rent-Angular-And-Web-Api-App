using MansionRentBackend.Application.Repositories;
using MansionRentBackend.Domain.IUnitOfWorks;

namespace MansionRentBackend.Application.UnitOfWorks;

public interface IApplicationUnitOfWork : IUnitOfWork
{
    IMansionRepository Mansions { get; }
}