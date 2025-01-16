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
       
        public virtual Profile? Profile { get; set; }

        public virtual Store? Store { get; set; }
        
        public virtual Customer? Customer { get; set; }
    }
}
