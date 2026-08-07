using System;
using System.Collections.Generic;
using System.Text;

namespace AirbnbCloneBackend.Application.Dtos.Auth
{
    public record AuthResponseDto(string Token, DateTime ExpiresAt, string Email, string Name);
    
}
