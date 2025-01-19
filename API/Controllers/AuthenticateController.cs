using Domain.DTOs.Request;
using Domain.Interfaces.IServices;
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
    }
}
