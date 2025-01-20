using Domain.DTOs.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IServices
{
    public interface IAccountService
    {
        public Task SignUpNewAccount(RequestDTORegister request);

        public Task ConfirmEmail(string UserId, string token);

        public Task FindAccountToResetPassword(string UsernameOrEmail);

        public Task ResetPassword(RequestDTOResetPassword request);
    }
}
