using MansionRentBackend.Application.BusinessObjects;

namespace MansionRentBackend.Application.Services
{
    public interface IUserService
    {
        Task<bool> IsUniqueUser(string username);
        Task<LoginResponse> Login(Login loginRequest);
        Task<LocalUser> Register(Registration registrationRequest);
    }
}