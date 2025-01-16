using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IRepositories
{
    public interface IRoleRepository : IGenericRepository<IdentityRole>
    {
        public RoleManager<IdentityRole> RoleManager { get; }
    }
}
