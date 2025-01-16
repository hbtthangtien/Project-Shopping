using Domain.Entities;
using Domain.Interfaces.IRepositories;
using Microsoft.AspNetCore.Identity;
using Persistence.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        public UserManager<Account> UserManager { get; private set; }

        public SignInManager<Account> SignInManager { get; private set; }

        public AccountRepository(TikilazapeeDbContext context,
            UserManager<Account> userManager,
            SignInManager<Account> signInManager)
            : base(context)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }
    }
}
