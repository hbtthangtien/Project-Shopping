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
    public class SubCategoryRepository : GenericRepository<SubCategory>, ISubCategoryRepository
    {
        public SubCategoryRepository(TikilazapeeDbContext context) : base(context)
        {
        }
    }
}
