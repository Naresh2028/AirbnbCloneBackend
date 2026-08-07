using System;
using System.Collections.Generic;
using System.Text;

namespace AirbnbCloneBackend.Application.Configuration
{
    public class JwtSettings
    {
        public required string Key { get; set; }
        public required string Issuer { get; set; }
        public required string Audience { get; set; }
        public int ExpiresInMinutes { get; set; }
    }

}
