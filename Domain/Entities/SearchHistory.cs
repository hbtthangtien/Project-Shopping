using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SearchHistory
    {
        public int SearchHistoryId { get; set; }
        public string? AccountId { get; set; }
        public string? SearchKey { get; set; }
        public virtual Account? Account { get; set; }
    }
}
