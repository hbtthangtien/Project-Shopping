using AutoMapper;
using Domain.Constants;
using Domain.DTOs.Request;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces.IRepositories;
using Domain.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AccountService : BaseService, IAccountService
    {
        public AccountService(IMapper mapper, IUnitOfWork unitOfWork) 
            : base(mapper, unitOfWork)
        {
        }

        public Task ConfirmEmail(string UserId, string token)
        {
            throw new NotImplementedException();
        }

        public async Task SignUpNewAccount(RequestDTORegister request)
        {
            if (request.Password!.Equals(request.ConfirmPassword))
            {
                var User = new Account
                {
                    Email = request.Email,
                    UserName = request.Username
                };
                var result = await _unitOfWork.Accounts.UserManager.CreateAsync(User,request.Password);
                var success = await _unitOfWork.Accounts.UserManager.AddToRoleAsync(User, UserRole.CUSTOMER);
                if (!result.Succeeded)
                {
                    throw new IdentityException(result.Errors);
                }
                if (!success.Succeeded)
                {
                    throw new IdentityException(result.Errors);
                }
            }else throw new Exception("Password and Confirm password is not same!");

        }
    }
}
