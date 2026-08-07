using AirbnbCloneBackend.Application.Interfaces.Repostiory;
using AirbnbCloneBackend.Domain.Models;
using AirbnbCloneBackend.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirbnbCloneBackend.Infrastructure.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly AppDbContext _dbContext; 
        public AuthRepository(AppDbContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public async Task CreateUserAsync(User user)
        {
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _dbContext.Users
                        .AsNoTracking()
                        .FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
