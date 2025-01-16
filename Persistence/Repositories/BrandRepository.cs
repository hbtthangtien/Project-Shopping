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
    public class BrandRepository : GenericRepository<Brand>, IBrandRepository
    {
        public BrandRepository(TikilazapeeDbContext context) : base(context)
        {
        }
    }
}
