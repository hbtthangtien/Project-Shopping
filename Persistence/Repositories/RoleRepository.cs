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
    public class RoleRepository : GenericRepository<IdentityRole>, IRoleRepository
    {
        public RoleManager<IdentityRole> RoleManager { get; private set; }
        public RoleRepository(TikilazapeeDbContext context, RoleManager<IdentityRole> role) : base(context)
        {
            RoleManager = role;
        }

        
    }
}
