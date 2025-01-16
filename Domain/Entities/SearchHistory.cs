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
        public string? CustomerId { get; set; }
        public string? SearchKey { get; set; }
        public DateTime? SearchLog {  get; set; } = DateTime.Now;
        public virtual Customer? Customer { get; set; }
    }
}
