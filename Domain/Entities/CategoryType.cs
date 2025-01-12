using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CategoryType
    {
        public int CategoryTypeID { get; set; }
        public string? CategoryTypeName { get; set; }
        public virtual ICollection<Type> CategoryTypes { get; set; } = new List<Type>()!;
    }
}
