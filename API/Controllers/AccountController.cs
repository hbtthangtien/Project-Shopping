using Domain.DTOs.Request;
using Domain.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpPost]
        public async Task<IActionResult> SignUpUser(RequestDTORegister request)
        {
            var user =await _accountService.SignUpNewAccount(request);
            return Ok(user);
        }
    }
}
