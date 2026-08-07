using AirbnbCloneBackend.Application.Dtos.Property;
using AirbnbCloneBackend.Application.Interfaces.Repostiory;
using AirbnbCloneBackend.Domain.Models;
using AirbnbCloneBackend.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace AirbnbCloneBackend.Infrastructure.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly AppDbContext _dbContext;
        public PropertyRepository(AppDbContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public async Task CreateAsync(Property property)
        {
            _dbContext.Properties.Add(property);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<PagedList<Property>> GetAllAsync(PropertyQuery request)
        {
            var properties = _dbContext.Properties
                            .OrderBy(p => p.PropertyName)
                            .AsNoTracking();

            // Search Filter
            if (!string.IsNullOrWhiteSpace(request.SearchQuery)) 
            {
                properties = properties.Where(p => p.PropertyName.Contains(request.SearchQuery));
            }

            // Status Filter
            if (request.Status.HasValue) 
            {
                properties = properties.Where(p => p.Status == request.Status.Value);
            }

            // Pagination
            var items = await properties
                        .Skip((request.PageNumber - 1) * request.PageSize)
                        .Take(request.PageSize)
                        .ToListAsync();

            var totalItems = await properties.CountAsync();


            return new PagedList<Property>(items,totalItems);
        }

        public async Task<Property?> GetByIdAsync(int id)
        {
            return await _dbContext.Properties
                        .AsNoTracking()
                        .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task UpdateAsync(Property property)
        {
            _dbContext.Properties.Update(property);
            await _dbContext.SaveChangesAsync();
        }
    }
}
