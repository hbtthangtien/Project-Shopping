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
        public int? SubCatecoryId { get; set; }
        public string? ProductDescribes { get; set; }
        public int? SaleLevel { get; set; } = 0;
        public bool? IsActived { get; set; }
        public virtual Brand? Brand { get; set; }
        public virtual Category? Category { get; set; }
        public virtual SubCategory? SubCategory { get; set; }
        public virtual ICollection<Type>? ProductTypes { get; set; } = new List<Type>()!;
        public virtual ICollection<Color>? ProductColors { get; set; }  = new List<Color>()!;    
        public virtual ICollection<ProductImages>? ProductImages { get; set; } = new List<ProductImages>()!;
        public virtual ICollection<ProductColorType>? ColorTypes { get; set; } = new List<ProductColorType>()!;
    }
}
