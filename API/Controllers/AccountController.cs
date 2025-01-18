using Domain.DTOs.Request;
using Domain.DTOs.Response;
using Domain.Interfaces.IServices;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    [Route("api/acounts")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpPost("sign-up")]
        public async Task<IActionResult> SignUpUser(RequestDTORegister request)
        {
           await _accountService.SignUpNewAccount(request);
            return Created("Sign up account", new ApiResponeDTO
            {
                Message = "Sign up successfully",
                Status = StatusCodes.Status201Created
            });
           
        }
    }
}
