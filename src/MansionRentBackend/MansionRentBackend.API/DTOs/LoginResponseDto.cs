using Autofac;
using AutoMapper;
using MansionRentBackend.Application.BusinessObjects;
using MansionRentBackend.Application.Services;
using System.Net;

namespace MansionRentBackend.API.DTOs;

public class LoginResponseDto : BaseDto
{
    public LocalUser User { get; set; }
    public string Token { get; set; }

    private IAccountService _accountService;
    private IMapper _mapper;

    public LoginResponseDto() : base() { }

    public LoginResponseDto(IMapper mapper, IAccountService accountService)
    {
        _accountService = accountService;
        _mapper = mapper;
    }

    public override void ResolveDependency(ILifetimeScope scope)
    {
        base.ResolveDependency(scope);
        _mapper = _scope.Resolve<IMapper>();
        _accountService = _scope.Resolve<IAccountService>();
    }

    internal async Task<LoginResponseDto> GetUserResult(string username, string password)
    {
        var model = new LoginResponseDto();
        var result = await _accountService.GetUserToken(username, password);

        return _mapper.Map<LoginResponseDto>(result);
    }
}