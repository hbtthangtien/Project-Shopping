using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Request
{
    public class RequestDTORegister
    {
        public string? Username { get; set; }
        public string? Email {  get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
    }
}
