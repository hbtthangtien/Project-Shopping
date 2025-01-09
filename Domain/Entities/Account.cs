using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Account : IdentityUser
    {
        public int ProfileId { get; set; }

        public DateTime? LatestLogin { get; set; } = DateTime.Now;

        public double? Score { get; set; } = 0;

        public virtual Profile? Profile { get; set; }

        public virtual IEnumerable<SearchHistory>? SearchHistories { get; set; } 
                        = Enumerable.Empty<SearchHistory>();
        

    }
}
