using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class OrderDetail
    {
        public int Id { get; set; }

        public int? ProductId { get; set; }

        public int? ColorId { get; set; }

        public int? TypeId { get; set; }

        public int? StoreId { get; set; }

        public int? Quantity { get; set; }

        public virtual Store? Store { get; set; }

        public virtual Product? Product { get; set; }

        public virtual Color? Color { get; set; }

        public virtual Type? Type { get; set; }

    }
}
