using MansionRentBackend.Application.DbContexts;
using MansionRentBackend.Domain.Entities;
using MansionRentBackend.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MansionRentBackend.Application.Repositories;

public class UserRepository : Repository<LocalUser, Guid>, IUserRepository
{
    private readonly IApplicationDbContext _dbContext;

    public UserRepository(IApplicationDbContext context) : base((DbContext)context)
    {
        _dbContext = context;
    }

    public async Task<LocalUser> GetUserDetails(string username, string password)
    {
        return _dbContext.LocalUsers.FirstOrDefault(u => u.UserName.ToLower() == username.ToLower() &&
            u.Password == password);
    }
}