using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Request
{
    public  class RequestDTOResetPassword
    {
        public string UserId { get; set; }
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string Token { get; set; }
    }
}
