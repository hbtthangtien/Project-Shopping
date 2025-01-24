using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Domain.Configs;
using Domain.Interfaces.IRepositories;
using Domain.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CloudinaryService : ICloudinaryService
    {
        private readonly Cloudinary cloudinary;
        private readonly CloundinaryConfig _config;
        public CloudinaryService(IOptions<CloundinaryConfig> options)
        {
            _config = options.Value;
            var Account = new Account(_config.CloudName, _config.ApiKey, _config.ApiSecret);
            cloudinary = new Cloudinary(Account);
        }

        public async Task<string> UploadImageFileAsync(IFormFile file, string username)
        {
            if(file == null || file.Length == 0)
            {
                throw new ArgumentNullException(nameof(file));
            }
            using (var stream = file.OpenReadStream())
            {
                var uploadParam = new ImageUploadParams
                {

                    File = new FileDescription(file.Name, stream),
                    Folder = $"{username}/images"
                };
                var uploadResult = await cloudinary.UploadAsync(uploadParam);
                return uploadResult.SecureUrl.ToString();
            }
        }
    }
}
