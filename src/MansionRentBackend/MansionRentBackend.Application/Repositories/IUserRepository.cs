using MansionRentBackend.Application.Entities;

namespace MansionRentBackend.Application.Repositories
{
    public interface IUserRepository : IRepository<LocalUser, Guid>
    {
        Task<LocalUser> GetUserDetails(string username, string password);
    }
}