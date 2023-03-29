using MansionRentBackend.Application.DbContexts;
using MansionRentBackend.Application.Entities;
using Microsoft.EntityFrameworkCore;

namespace MansionRentBackend.Application.Repositories
{
    public class VillaRepository : Repository<Mansion, Guid>, IVillaRepository
    {
        public VillaRepository(IApplicationDbContext context) : base((DbContext)context)
        {

        }
    }
}