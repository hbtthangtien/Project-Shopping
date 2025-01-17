using AutoMapper;
using Domain.DTOs.Request;
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

        public async Task<RequestDTORegister?> SignUpNewAccount(RequestDTORegister request)
        {
             
            return request!;
        }
    }
}
