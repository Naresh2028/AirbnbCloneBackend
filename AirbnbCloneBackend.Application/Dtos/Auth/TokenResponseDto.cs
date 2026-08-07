using System;
using System.Collections.Generic;
using System.Text;

namespace AirbnbCloneBackend.Application.Dtos.Auth
{
    public record TokenResponseDto(string Token, DateTime ExpiresAt);
}
