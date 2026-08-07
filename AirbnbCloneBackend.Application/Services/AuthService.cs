using AirbnbCloneBackend.Application.Configuration;
using AirbnbCloneBackend.Application.Dtos.Auth;
using AirbnbCloneBackend.Application.Interfaces.Auth;
using AirbnbCloneBackend.Application.Interfaces.Repostiory;
using AirbnbCloneBackend.Domain.Models;
using BCrypt.Net;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;

namespace AirbnbCloneBackend.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _repo;
        private readonly JwtSettings _jwtSettings;
        public AuthService(IAuthRepository repo, IOptions<JwtSettings> jwtSettings) 
        {
            _repo = repo;
            _jwtSettings = jwtSettings.Value;
        }
        public async Task<AuthResponseDto> LoginAsync(LoginRequestDto request)
        {
            var normalizedEmail = request.Email.Trim().ToLowerInvariant();

            var existingUser = await _repo.GetByEmailAsync(normalizedEmail);

            if(existingUser is null || !(BCrypt.Net.BCrypt.Verify(request.Password, existingUser.PasswordHash) )) throw new InvalidOperationException("Invalid email or password!");

            var tokenResponse = GenerateToken(existingUser);

            return new AuthResponseDto(tokenResponse.Token, tokenResponse.ExpiresAt, existingUser.Email,existingUser.Name);

        }

        public async Task<bool> SignupAsync(SignupRequest request)
        {
            var normalizedEmail = request.Email.Trim().ToLowerInvariant();

            var existingUser = await _repo.GetByEmailAsync(normalizedEmail);

            if (existingUser != null) throw new InvalidOperationException("Email already exists.");

            var user = new User 
            {
                Id = Guid.NewGuid(),
                Email = normalizedEmail,
                Name = request.Name.Trim(),
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                CreatedAt = DateTime.UtcNow
            };

            await _repo.CreateUserAsync(user);

            return true;
        }

        private TokenResponseDto GenerateToken(User user) 
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            
            var expiresAt = DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiresInMinutes);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim(ClaimTypes.Name,user.Name),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            var signingAlgorithm = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience:_jwtSettings.Audience,
                claims:claims,
                expires: expiresAt,
                signingCredentials: signingAlgorithm
             );

            return new TokenResponseDto(new JwtSecurityTokenHandler().WriteToken(token), expiresAt);
        }
    }
}
