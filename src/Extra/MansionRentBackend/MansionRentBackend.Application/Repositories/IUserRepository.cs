using MansionRentBackend.Application.Entities;

namespace MansionRentBackend.Application.Repositories
{
    public interface IUserRepository : IRepository<LocalUser, int>
    {
        Task<LocalUser> GetUserDetails(string username, string password);
    }
}