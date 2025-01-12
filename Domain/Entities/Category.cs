using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public virtual ICollection<SubCategory> SubCategories { get; set; } = new List<SubCategory>()!;
        public virtual ICollection<Product> Products { get; set; } = new List<Product>()!;


    }
}
