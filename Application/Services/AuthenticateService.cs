using AutoMapper;
using Domain.Configs;
using Domain.Constants;
using Domain.DTOs.Request;
using Domain.DTOs.Response;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces.IRepositories;
using Domain.Interfaces.IServices;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Application.Services
{
    public class AuthenticateService : BaseService, IAuthenticateService
    {

        private readonly JwtConfigs _jwtConfigs;
        private readonly ISenderService _email;
        public AuthenticateService(IMapper mapper, IUnitOfWork unitOfWork,
            IOptions<JwtConfigs> options, ISenderService senderService) 
            : base(mapper, unitOfWork)
        {
            _jwtConfigs = options.Value;
            _email = senderService;
        }

        public async Task<string> GenerateToken(Account account)
        {
            var roles = await _unitOfWork.Accounts.UserManager.GetRolesAsync(account);
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, account.UserName!),
                new Claim(ClaimTypes.Email, account.Email!),
                new Claim("ID", account.Id!),
            };
            foreach(var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role,role));
            }
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfigs.Token));
            var creds = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken
                (
                    issuer: _jwtConfigs.ValidIssuer,
                    audience: _jwtConfigs.ValidAudience,
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(_jwtConfigs.TokenValidityInMinutes),
                    signingCredentials: creds
                ) ;
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<ResponseLoginDTO> LoginAsync(RequestDTOLogin requestDTO)
        {
            var User = (requestDTO.Username.Contains('@')) 
                ? await _unitOfWork.Accounts.UserManager.FindByEmailAsync(requestDTO.Username)   
                :await _unitOfWork.Accounts.UserManager.FindByNameAsync(requestDTO.Username) ??
                throw new IdentityException("Username is not exist");
            var login = await _unitOfWork.Accounts.SignInManager
                .PasswordSignInAsync(User!.UserName!, requestDTO.Password,false,lockoutOnFailure:false) ;
            if (login.Succeeded)
            {                               
                bool checkEmailConfirm = await _unitOfWork.Accounts.UserManager.IsEmailConfirmedAsync(User!);
                if (!checkEmailConfirm)
                {
                    var token = await _unitOfWork.Accounts.UserManager.GenerateEmailConfirmationTokenAsync(User);
                    var baseUri = $"https://localhost:5000//";
                    var uriBuilder = LinkConstant.UriBuilder(User.Id, token, "accounts/confirm-email");
                    var link = uriBuilder.ToString();
                    await _email.Send(User.Email!, EmailSubject.CONFIRM_EMAIL, BodyEmail.Body(User.Email!, link));
                    throw new AuthenticationException("Email is not authenticated!!!");
                }
                string Token = await GenerateToken(User!);
                string refreshToken = await GenerateRefreshToken();
                return new ResponseLoginDTO
                {
                    Token = Token,
                    RefreshToken = refreshToken                    
                };
            } else if (login.IsLockedOut)
            {
                throw new AuthenticationException("Account has been locked out!!!");
            }else if(login.IsNotAllowed)
            {
                throw new AuthenticationException("Account is not allowed!!!");
            }
            else
            {
                throw new AuthenticationException("Username or Password is not correct!!!");
            }            
        }

        public async Task Logout()
        {
            await _unitOfWork.Accounts.SignInManager.SignOutAsync();
        }

        private async Task<string> GenerateRefreshToken()
        {
            return await Task.Run(() =>
            {
                byte[] random = new byte[32];
                using (var rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(random);
                }
                return Convert.ToBase64String(random);
            });
        }
    }
}
