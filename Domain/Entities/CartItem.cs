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

        public virtual int? ProductColorTypeId { get; set;}

        public int? Quantity { get; set; } = 0;
        [NotMapped]
        public double? TotalPrice => (Quantity * ProductColorType?.TotalPrice);

        public virtual string? AccountId {  get; set; }
        
        public virtual Account? Account { get; set; }

        public virtual ProductColorType? ProductColorType { get; set; }
    }
}
