using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Store
    {
        public int StoreId {  get; set; }

        public string? StoreName { get; set; }

        public string? StorePhone { get; set; }

        public string? StoreEmail { get; set; }

        public string? StoreAddress { get; set; }

        public string? StoreImage { get; set; }

        public string? AccountId { get; set; }
        public virtual Account? Account { get; set; }
        public virtual ICollection<Product>? Products { get; set; } = new List<Product>();

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>()!; 


    }
}
