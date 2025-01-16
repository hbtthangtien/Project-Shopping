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
    public class SearchHistoryRepository : GenericRepository<SearchHistory>, ISearchHistoryRepository
    {
        public SearchHistoryRepository(TikilazapeeDbContext context) : base(context)
        {
        }
    }
}
