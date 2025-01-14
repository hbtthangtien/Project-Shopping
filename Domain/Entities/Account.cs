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
        public DateTime? LatestLogin { get; set; } = DateTime.Now;

        public double? Score { get; set; } = 0;

        public virtual Profile? Profile { get; set; }

        public virtual ICollection<SearchHistory>? SearchHistories { get; set; } = new List<SearchHistory>();
        
        public virtual ICollection<CartItem>? CartItems { get; set; } = new List<CartItem>()!;
        
        public virtual ICollection<Order>? Orders { get; set; } = new List<Order>()!;
    }
}
