﻿using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IRepositories
{
    public interface IAccountRepository : IGenericRepository<Account>
    {
        public UserManager<Account> UserManager { get; }

        public SignInManager<Account> SignInManager { get; }

        
    }
}
