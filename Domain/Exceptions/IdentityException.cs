using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class IdentityException : Exception
    {
        public IdentityException(IEnumerable<IdentityError> errors)
            :base(string.Join(";", errors.Select(e => $"{e.Description}")))
        { }

        public IdentityException(string? message) : base(message)
        {
        }
    }
}
