using MansionRentBackend.Application.BusinessObjects;

namespace MansionRentBackend.Application.Services;

public interface IAccountService
{
    Task<LoginRequestBO> GetUserToken(string email, string password);
}