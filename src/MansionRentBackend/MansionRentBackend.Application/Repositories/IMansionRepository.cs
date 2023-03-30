using MansionRentBackend.Application.Entities;
using MansionRentBackend.Domain.Repositories;

namespace MansionRentBackend.Application.Repositories;

public interface IMansionRepository : IRepository<Mansion, Guid>
{

}