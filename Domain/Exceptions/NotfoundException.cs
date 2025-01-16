using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class NotfoundException : Exception
    {
        public NotfoundException() { }

        public NotfoundException(string? message) : base(message)
        {
        }

        public NotfoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NotfoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
