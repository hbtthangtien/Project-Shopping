using AutoMapper;
using Domain.Constants;
using Domain.DTOs.Request;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces.IRepositories;
using Domain.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AccountService : BaseService, IAccountService
    {
        private readonly ISenderService _mail;
        private readonly ICloudinaryService _cloudinary;
        public AccountService(IMapper mapper, IUnitOfWork unitOfWork,
                ISenderService senderService, ICloudinaryService cloudinary)
            : base(mapper, unitOfWork)
        {
            _mail = senderService;
            _cloudinary = cloudinary;
        }

        public async Task ConfirmEmail(string UserId, string token)
        {
            var user = await _unitOfWork.Accounts.UserManager.FindByIdAsync(UserId)
                        ?? throw new IdentityException("User is not existed!!!");
            var result = await _unitOfWork.Accounts.UserManager.ConfirmEmailAsync(user, token);
            if (!result.Succeeded)
            {
                throw new IdentityException("Token is not invalid! Please try again!");
            }
        }

        public async Task FindAccountToResetPassword(string UsernameOrEmail)
        {
            var User = (UsernameOrEmail.Contains('@'))
                 ? await _unitOfWork.Accounts.UserManager.FindByEmailAsync(UsernameOrEmail)
                 : await _unitOfWork.Accounts.UserManager.FindByNameAsync(UsernameOrEmail) ??
                 throw new IdentityException("Username is not exist");
            string Token = await _unitOfWork.Accounts.UserManager.GeneratePasswordResetTokenAsync(User!);
            var uriBuilder = LinkConstant.UriBuilder(User!.Id, Token, "accounts/reset-password");
            var link = uriBuilder.ToString();
            await _mail.Send(User.Email!, EmailSubject.RESET_PASSWORD, BodyEmail.BodyResetPassword(User.Email!, link));
        }

        public async Task RegisterStore(RequestDTORegisterStore request, IFormFile file)
        {
            await _unitOfWork.Stores.BeginTransactionAsync();
            try
            {
                var user = await _unitOfWork.Accounts.GetByIdAsync(request.AccountId!);
                string link = await _cloudinary.UploadImageFileAsync(file, user.UserName!);
                request.StoreImage = link;
                var store = _mapper.Map<Store>(request);
                await _unitOfWork.Stores.AddAsync(store);
                await _unitOfWork.Accounts.UserManager.AddToRoleAsync(user,UserRole.SELLER);
                await _unitOfWork.CommitAsync();
                await _unitOfWork.Stores.CommitTransactionAsync();
                await _mail.Send(user.Email!, EmailSubject.WELCOME_SELLER, BodyEmail.BodyRegisterStore(user.Email!,""));
            }catch(Exception ex)
            {
                await _unitOfWork.Stores.RollbackTransactionAsync();
                throw ex;
            }

        }

        public async Task ResetPassword(RequestDTOResetPassword request)
        {
            if (request.Password.Equals(request.ConfirmPassword))
            {
                var user = await _unitOfWork.Accounts.UserManager.FindByIdAsync(request.UserId)
                        ?? throw new Exception("User is not existed!!!");
                var result = await _unitOfWork.Accounts.UserManager.ResetPasswordAsync(user, request.Token, request.Password);
                if (!result.Succeeded)
                {
                    throw new IdentityException(result.Errors);
                }
            }
            else
            {
                throw new Exception("Password and Confirm password is not the same!!!");
            }

        }

        public async Task SignUpNewAccount(RequestDTORegister request)
        {

            if (request.Password!.Equals(request.ConfirmPassword))
            {
                await _unitOfWork.Accounts.BeginTransactionAsync();
                var User = new Account
                {
                    Email = request.Email,
                    UserName = request.Username
                };
                var result = await _unitOfWork.Accounts.UserManager.CreateAsync(User, request.Password);
                var success = await _unitOfWork.Accounts.UserManager.AddToRoleAsync(User, UserRole.CUSTOMER);

                if (!result.Succeeded)
                {
                    await _unitOfWork.Accounts.RollbackTransactionAsync();
                    throw new IdentityException(result.Errors);
                }
                if (!success.Succeeded)
                {
                    await _unitOfWork.Accounts.RollbackTransactionAsync();
                    throw new IdentityException(result.Errors);
                }

                var token = await _unitOfWork.Accounts.UserManager.GenerateEmailConfirmationTokenAsync(User);
                var baseUri = $"https://localhost:5000//api";
                var uriBuilder = LinkConstant.UriBuilder(User.Id, token, "accounts/confirm-email");
                var link = uriBuilder.ToString();
                await _mail.Send(User.Email!, EmailSubject.CONFIRM_EMAIL, BodyEmail.Body(User.Email!, link));
                await _unitOfWork.Accounts.CommitTransactionAsync();
            }
            else throw new Exception("Password and Confirm password is not same!");

        }


    }
}
