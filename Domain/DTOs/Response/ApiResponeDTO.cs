using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Response
{
    public class ApiResponeDTO
    {
        public int Status { get; set; }

        public object Message { get; set; }
    }
}
