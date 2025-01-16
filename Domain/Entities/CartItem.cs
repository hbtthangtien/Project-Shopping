using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CartItem
    {
        public int CartItemId { get; set; }
        public int? ProductColorTypeId { get; set;}
        public int? ProductId { get; set; }
        public int? ColorId { get; set; }
        public int? TypeId { get; set; }
        public int? Quantity { get; set; } = 0;
        public string? CustomerId {  get; set; }        
        public virtual Customer? Customer { get; set; }
        public virtual Product? Product { get; set; }
        public virtual Type? Type { get; set; }
        public virtual Color? Color { get; set; }

    }
}
