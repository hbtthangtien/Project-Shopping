using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProductImages
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public string? UrlImage { get; set; }
        public virtual Product? Product { get; set; }

    }
}
