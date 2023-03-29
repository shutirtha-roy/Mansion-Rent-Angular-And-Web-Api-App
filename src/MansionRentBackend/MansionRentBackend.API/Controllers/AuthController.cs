using Autofac;
using Azure;
using MansionRentBackend.API.DTOs;
using MansionRentBackend.Application.BusinessObjects;
using MansionRentBackend.Application.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Authentication;

namespace MansionRentBackend.API.Controllers
{
    [Route("api/v1/Auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly ILogger<AuthController> _logger;
        private readonly ILifetimeScope _scope;
        private readonly APIResponse _response;

        public AuthController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<ApplicationRole> roleManager,
            ILogger<AuthController> logger, ILifetimeScope scope)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _logger = logger;
            _scope = scope;
            _response = _scope.Resolve<APIResponse>();
        }

        [HttpPost("register")]
        public async Task<object> Register(RegistrationRequestDto dtoRegistration)
        {
            try
            {
                var user = new ApplicationUser
                {
                    UserName = dtoRegistration.UserName,
                    Email = dtoRegistration.UserName,
                    Name = dtoRegistration.Name,
                };

                var result = await _userManager.CreateAsync(user, dtoRegistration.Password);

                if (!result.Succeeded)
                {
                    throw new AuthenticationException();
                }

                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Error while registering");
                return BadRequest(_response);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDto loginDto)
        {
            var loginReponse = new LoginResponseDto();
            loginReponse.ResolveDependency(_scope);
            loginReponse = await loginReponse.GetUserResult(loginDto.UserName, loginDto.Password);

            if (loginReponse.User == null || string.IsNullOrEmpty(loginReponse.Token))
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.Result = null;
                _response.ErrorMessages.Add("User or password is incorrect.");
                return BadRequest(_response);
            }

            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            _response.Result = loginReponse;
            return Ok(_response);
        }
    }
}