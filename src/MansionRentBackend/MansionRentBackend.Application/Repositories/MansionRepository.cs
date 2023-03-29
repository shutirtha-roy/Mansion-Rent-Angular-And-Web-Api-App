using MansionRentBackend.Application.DbContexts;
using MansionRentBackend.Application.Entities;
using Microsoft.EntityFrameworkCore;

namespace MansionRentBackend.Application.Repositories;

public class MansionRepository : Repository<Mansion, Guid>, IMansionRepository
{
    public MansionRepository(IApplicationDbContext context) : base((DbContext)context)
    {

    }
}