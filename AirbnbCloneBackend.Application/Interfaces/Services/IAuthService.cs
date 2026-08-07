using AirbnbCloneBackend.Application.Dtos.Auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirbnbCloneBackend.Application.Interfaces.Auth
{
    public interface IAuthService
    {
        Task<bool> SignupAsync(SignupRequest request);
        Task<AuthResponseDto> LoginAsync(LoginRequestDto request);
    }
}
