using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SubCategory
    {
        public int SubCategoryId {  get; set; }
        public string? SubCategoryName { get; set;}
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();


    }
}
