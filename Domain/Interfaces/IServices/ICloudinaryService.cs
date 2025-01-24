using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IServices
{
    public interface ICloudinaryService
    {
        public Task<string> UploadImageFileAsync(IFormFile file, string username);
    }
}
