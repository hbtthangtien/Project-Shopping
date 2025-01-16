using Domain.Entities;
using Domain.Interfaces.IRepositories;
using Persistence.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class TypeRepository : GenericRepository<Domain.Entities.Type>, ITypeRepository
    {
        public TypeRepository(TikilazapeeDbContext context) : base(context)
        {
        }
    }
}
