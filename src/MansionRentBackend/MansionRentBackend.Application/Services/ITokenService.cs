using System.Security.Claims;

namespace MansionRentBackend.Application.Services;

public interface ITokenService
{
    Task<string> GetJwtToken(IList<Claim> claims);
}