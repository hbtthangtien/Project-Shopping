using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public int? BrandId { get; set; }
        public int? CategoryId { get; set; }
        public string? ProductName { get; set; }
        public string? SubCatecoryId { get; set; }
        public string? ProductDescribes { get; set; }
        public int? SaleLevel { get; set; } = 0;
        public bool? IsActived { get; set; }
        public virtual Brand? Brand { get; set; }
        public virtual Category? Category { get; set; }
        public virtual SubCategory? SubCategory { get; set; }
        public virtual IEnumerable<Type>? ProductTypes { get; set; } = Enumerable.Empty<Type>()!;
        public virtual IEnumerable<Color>? ProductColors { get; set; }  = Enumerable.Empty<Color>()!;    
        public virtual IEnumerable<ProductColorType>? ColorTypes { get; set; } = Enumerable.Empty<ProductColorType>()!;
        public virtual IEnumerable<ProductImages>? ProductImages { get; set; } = Enumerable.Empty<ProductImages>()!;
    }
}
