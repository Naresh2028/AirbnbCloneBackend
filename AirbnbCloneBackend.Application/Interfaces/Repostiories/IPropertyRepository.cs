using AirbnbCloneBackend.Application.Dtos.Property;
using AirbnbCloneBackend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirbnbCloneBackend.Application.Interfaces.Repostiory
{
    public interface IPropertyRepository
    {
        Task<PagedList<Property>> GetAllAsync(PropertyQuery request);
        Task<Property?> GetByIdAsync(int id);
        Task CreateAsync(Property property);
        Task UpdateAsync(Property property);
    }
}
