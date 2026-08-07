using AirbnbCloneBackend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirbnbCloneBackend.Application.Interfaces.Repostiory
{
    public interface IAuthRepository
    {
        Task<User?> GetByEmailAsync(string email);
        Task CreateUserAsync(User user);
    }
}
