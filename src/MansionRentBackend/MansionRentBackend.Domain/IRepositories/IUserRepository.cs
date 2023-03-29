using MansionRentBackend.Domain.Entities;

namespace MansionRentBackend.Domain.Repositories
{
    public interface IUserRepository : IRepository<LocalUser, Guid>
    {
        Task<LocalUser> GetUserDetails(string username, string password);
    }
}