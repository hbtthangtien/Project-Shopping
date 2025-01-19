using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IServices
{
    public interface ISenderService
    {
        public Task Send(string UserId, string token, string email);
    }
}
