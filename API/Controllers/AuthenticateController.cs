using Domain.DTOs.Request;
using Domain.DTOs.Response;
using Domain.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IAuthenticateService _authenticate;
        public AuthenticateController(IAuthenticateService authenticate)
        {
            _authenticate = authenticate;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(RequestDTOLogin request)
        {
            var token = await _authenticate.LoginAsync(request);
            return Ok(token);
        }

        [HttpPost("log-out")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _authenticate.Logout();
            return Ok(new ApiResponeDTO
            {
                Message = "Logout successfully",
                Status = StatusCodes.Status200OK,
            }) ;
        }
    }
}
