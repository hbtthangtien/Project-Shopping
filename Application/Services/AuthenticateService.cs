using AutoMapper;
using Domain.Configs;
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
        public AuthenticateService(IMapper mapper, IUnitOfWork unitOfWork, IOptions<JwtConfigs> options) 
            : base(mapper, unitOfWork)
        {
            _jwtConfigs = options.Value;
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
            var login = await _unitOfWork.Accounts.SignInManager
                .PasswordSignInAsync(requestDTO.Username, requestDTO.Password,false,lockoutOnFailure:false) ;
            if (login.Succeeded)
            {
               
                var User = await _unitOfWork.Accounts.UserManager.FindByNameAsync(requestDTO.Username);
                bool checkEmailConfirm = await _unitOfWork.Accounts.UserManager.IsEmailConfirmedAsync(User!);
                if (!checkEmailConfirm) throw new AuthenticationException("Email is not authenticated!!!");
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
