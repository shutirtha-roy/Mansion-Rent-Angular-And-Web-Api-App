using MansionRentBackend.Application.DbContexts;
using MansionRentBackend.Application.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MansionRentBackend.Application.UnitOfWorks
{
    public class ApplicationUnitOfWork : UnitOfWork, IApplicationUnitOfWork
    {
        public IVillaRepository Villas { get; private set; }
        public IUserRepository Users { get; private set; }

        public ApplicationUnitOfWork(IApplicationDbContext dbContext, 
            IVillaRepository villaRepository,
            IUserRepository userRepository) : base((DbContext)dbContext)
        {
            Villas = villaRepository;
            Users = userRepository;
        }
    }
}