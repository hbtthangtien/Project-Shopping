using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Order
    {
        public int OrderId { get; set; }

        public string? CustomerId { get; set; }

        public double? TotalPrice { get; set; }

        public DateTime? OrderDate { get; set; }

        public OrderStatus? Status { get; set; }

        public double? UseScore { get; set; }

        public double? AddScore { get; set; }

        public bool? IsFeedback { get; set; }

        public int? StoreId { get; set; }

        public virtual Store? Store { get; set; }

        public virtual Customer? Customer { get; set; }

        public virtual ICollection<OrderDetail> Details { get; set; } = new List<OrderDetail>()!;    
    }
}
