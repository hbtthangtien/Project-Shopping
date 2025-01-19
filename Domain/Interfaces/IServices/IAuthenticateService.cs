using Domain.DTOs.Request;
using Domain.DTOs.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IServices
{
    public interface IAuthenticateService
    {
        public Task<ResponseLoginDTO> LoginAsync(RequestDTOLogin requestDTO);

        public Task<string> GenerateToken(Account account);
    }
}
