using AirbnbCloneBackend.Application.Dtos.Property;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Text;

namespace AirbnbCloneBackend.Application.Interfaces.Service
{
    public interface IPropertyService
    {
        Task<PagedList<PropertyResponseDto>> GetAllAsync(PropertyQuery query);
        Task<PropertyResponseDto?> GetByIdAsync(int id);
        Task<PropertyResponseDto> CreateAsync(CreatePropertyRequestDto request, Guid userId, IFormFile file);
        Task<bool> UpdateAsync(int id, UpdatePropertyRequestDto request);
        Task<bool> UpdateStatusAsync(int id, bool status);
    }
}
