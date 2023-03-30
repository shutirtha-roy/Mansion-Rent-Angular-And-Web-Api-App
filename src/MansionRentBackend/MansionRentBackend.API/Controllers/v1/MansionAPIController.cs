using Autofac;
using MansionRentBackend.API.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;
using System.Text.Json;

namespace MansionRentBackend.API.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize(Policy = "ApiProjectListRequirementPolicy")]
    public class MansionAPIController : ControllerBase
    {
        private readonly ILifetimeScope _scope;
        private readonly APIResponse _response;

        public MansionAPIController(ILifetimeScope scope)
        {
            _scope = scope;
            _response = _scope.Resolve<APIResponse>();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<object>> Get()
        {
            var id = Guid.Parse(User.FindFirstValue(ClaimTypes.Sid));

            try
            {
                var mansionDto = _scope.Resolve<MansionListDto>();
                var mansions = await mansionDto.GetAllMansions();

                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.ErrorMessages = new List<string>();
                _response.Result = mansions;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>()
                {
                    ex.Message
                };
                _response.Result = null;

                return BadRequest(_response);
            }
        }

        [HttpGet("{id}")]
        public async Task<object> Get([FromRoute] Guid id)
        {
            try
            {
                var mansionDto = _scope.Resolve<MansionListDto>();
                var mansion = await mansionDto.GetMansion(id);

                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.ErrorMessages = new List<string>();
                _response.Result = mansion;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>()
                {
                    ex.Message
                };
                _response.Result = null;

                return BadRequest(_response);
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] MansionCreateDto mantionDto)
        {
            try
            {
                var id = Guid.Parse(User.FindFirstValue(ClaimTypes.Sid));
                mantionDto.ResolveDependency(_scope);
                await mantionDto.CreateMantion(id);

                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                _response.ErrorMessages = new List<string>();
                _response.Result = null;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>()
                {
                    ex.Message
                };
                _response.Result = null;

                return BadRequest(_response);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            try
            {
                var mansionDto = _scope.Resolve<MansionListDto>();
                await mansionDto.DeleteMansion(id);

                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                _response.ErrorMessages = new List<string>();
                _response.Result = null;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>()
                {
                    ex.Message
                };
                _response.Result = null;

                return BadRequest(_response);
            }
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Put([FromBody] MansionEditDto mansionDto)
        {
            try
            {
                var id = Guid.Parse(User.FindFirstValue(ClaimTypes.Sid));
                mansionDto.ResolveDependency(_scope);
                await mansionDto.EditMansion(id);

                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                _response.ErrorMessages = new List<string>();
                _response.Result = null;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>()
                {
                    ex.Message
                };
                _response.Result = null;

                return BadRequest(_response);
            }
        }
    }
}