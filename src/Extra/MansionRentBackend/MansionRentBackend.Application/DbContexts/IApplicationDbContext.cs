using MansionRentBackend.Application.Entities;
using Microsoft.EntityFrameworkCore;

namespace MansionRentBackend.Application.DbContexts
{
    public interface IApplicationDbContext
    {
        public DbSet<Mansion> Mansions { get; set; }
        public DbSet<LocalUser> LocalUsers { get; set; }
    }
}