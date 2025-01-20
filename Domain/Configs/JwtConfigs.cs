using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Configs
{
    public class JwtConfigs
    {
        public required bool ValidateIssuer { get; set; }
        public required string ValidIssuer { get; set; }
        public required bool ValidateAudience { get; set; }
        public required string ValidAudience { get; set; }
        public bool ValidateLifetime { get; set; }
        public bool ValidateIssuerSigningKey { get; set; }
        public required string Token { get; set; }
        public bool RequireExpirationTime { get; set; }
        public bool SaveToken { get; set; }
        public int TokenValidityInMinutes { get; set; }
        public int RefreshTokenValidityInDays { get; set; }
    }
}
