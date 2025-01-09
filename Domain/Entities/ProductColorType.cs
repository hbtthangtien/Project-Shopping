using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProductColorType
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public int? TypeId { get; set; }
        public int? ColorId { get; set; }
        public double? OriginPrice { get; set; }
        public int? Available { get; set; }
        public bool IsSale { get; set; } = false;
        [NotMapped]
        public double? TotalPrice  => (IsSale ?(OriginPrice - OriginPrice * Product!.SaleLevel) : OriginPrice);
        public virtual Product? Product { get; set; }
        public virtual Color? Color { get; set;}
        public virtual Type? Type { get; set; }


    }
}
