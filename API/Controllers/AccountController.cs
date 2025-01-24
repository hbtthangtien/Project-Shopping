using Domain.Constants;
using Domain.DTOs.Request;
using Domain.DTOs.Response;
using Domain.Interfaces.IRepositories;
using Domain.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;
using System.Text.Json;

namespace API.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IUnitOfWork _unitOfWork;
        public AccountController(IAccountService accountService, IUnitOfWork unitOfWork)
        {
            _accountService = accountService;
            _unitOfWork = unitOfWork;
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
        [HttpGet("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(string userId, string  token)
        {
            await _accountService.ConfirmEmail(userId, token);
            return Ok(new ApiResponeDTO
            {
                Message = "Confirm email successfully",
                Status = 200
            });
        }
        [HttpGet("reset-password")]
        public async Task<IActionResult> ResetPassword(string userId, string token)
        {
            await Task.Delay(0);
             return Ok(new
            {
                UserId = userId,
                Token = token
            });
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(RequestDTOResetPassword request)
        {
            await _accountService.ResetPassword(request);
            return StatusCode(205,(new ApiResponeDTO
            {
                Message = "Reset password successfully!!",
                Status = StatusCodes.Status205ResetContent
            }));
        }
        [HttpGet("find-account/{UsernameOrEmail}")]
        public async Task<IActionResult> FindAccount(string UsernameOrEmail)
        {
            await _accountService.FindAccountToResetPassword(UsernameOrEmail);
            return Ok();
        }

        [HttpPost("register-store")]
        [Authorize]
        public async Task<IActionResult> RegisterStore(IFormFile file,[FromForm]RequestDTORegisterStore request)
        {
            var Id = HttpContext.User.Claims.FirstOrDefault(e => e.Type.Equals("ID"))!.Value;
            request.AccountId = Id;
            await _accountService.RegisterStore(request,file);
            return Ok();

        }
        [HttpGet]
        [Authorize(Roles = UserRole.ADMIN)]
        public async Task<IActionResult> GetRole()
        {
            var roles =await _unitOfWork.Accounts.GetByIdAsync("1");
            var claims = HttpContext.User.Claims.Select(e => new
            {
                Type = e.Type,
                Name = e.Value.ToString()
            });
            //var json = JsonSerializer.Serialize(claims);
            return Ok(claims);
        }
    }
}
