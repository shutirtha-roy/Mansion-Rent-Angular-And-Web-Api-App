using Autofac;
using AutoMapper;
using MansionRentBackend.API.DTOs;
using MansionRentBackend.Application.BusinessObjects;
using MansionRentBackend.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MansionRentBackend.API.Controllers
{
    [Route("api/v1/UsersAuth")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly APIResponse _response;
        private readonly ILifetimeScope _scope;

        public UsersController(ILifetimeScope scope, IUserService userService, IMapper mapper)
        {
            _scope = scope;
            _userService = userService;
            _mapper = mapper;
            _response = _scope.Resolve<APIResponse>();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDto loginDto)
        {
            var loginReponse = await _userService.Login(_mapper.Map<Login>(loginDto));
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

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegistrationRequestDto dtoRegistration)
        {
            var ifUserNameUnique = await _userService.IsUniqueUser(dtoRegistration.UserName);
            if (!ifUserNameUnique)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Username already exists");
                return BadRequest(_response);
            }

            var user = await _userService.Register(_mapper.Map<Registration>(dtoRegistration));
            if (user == null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Error while registering");
                return BadRequest(_response);
            }

            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            return Ok(_response);
        }
    }
}