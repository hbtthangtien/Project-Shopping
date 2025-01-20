using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Response
{
    public class ResponseLoginDTO
    {
        public string? Token { get; set; }

        public string? RefreshToken { get; set; }
    }
}
