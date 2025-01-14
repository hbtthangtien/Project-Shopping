using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Type
    {
        public int TypeId { get; set; }
        public int? CategoryTypeId { get; set; }
        public string? TypeName { get; set; }
        public virtual CategoryType? CategoryType { get; set; }

        
    }
}
