using AutoMapper;
using MansionRentBackend.Application.BusinessObjects;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using ApplicationUserEO = MansionRentBackend.Application.Entities.ApplicationUser;

namespace MansionRentBackend.Application.Services;

public class AccountService : IAccountService
{
    private readonly SignInManager<ApplicationUserEO> _signInManager;
    private readonly UserManager<ApplicationUserEO> _userManager;
    private readonly ITokenService _tokenService;
    private readonly IMapper _mapper;

    public AccountService(SignInManager<ApplicationUserEO> signInManager,
        UserManager<ApplicationUserEO> userManager,
        ITokenService tokenService,
        IMapper mapper)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _tokenService = tokenService;
        _mapper = mapper;
    }

    public async Task<LoginRequestBO> GetUserToken(string email, string password)
    {
        var applicationUser = await _userManager.FindByEmailAsync(email);

        if (applicationUser != null)
        {
            var result = await _signInManager.CheckPasswordSignInAsync(applicationUser, password, true);

            if (result != null && result.Succeeded)
            {
                var claims = (await _userManager.GetClaimsAsync(applicationUser)).ToList();
                claims.Add(new Claim(ClaimTypes.Sid, applicationUser.Id.ToString()));
                var jwtToken = await _tokenService.GetJwtToken(claims);

                var userBO = new LoginRequestBO
                {
                    User = new LocalUser
                    {
                        Id = applicationUser.Id,
                        Name = applicationUser.Name,
                        UserName = applicationUser.UserName,
                        Password = applicationUser.PasswordHash,
                        Role = "admin"
                    },
                    Token = jwtToken
                };

                return userBO;
            }
        }

        return null;
    }
}