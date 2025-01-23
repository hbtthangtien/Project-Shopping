using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Request
{
    public class RequestDTORegisterStore
    {
        public string? StoreName { get; set; }

        public string? StorePhone { get; set; }

        public string? StoreEmail { get; set; }

        public string? StoreAddress { get; set; }

        public string? StoreImage { get; set; }

        public string? AccountId { get; set; }
    }
}
