﻿using Domain.DTOs.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IServices
{
    public interface IAccountService
    {
        public Task<RequestDTORegister> SignUpNewAccount(RequestDTORegister request);
    }
}
