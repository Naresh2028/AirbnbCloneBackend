using AirbnbCloneBackend.Application.Dtos.Property;
using AirbnbCloneBackend.Application.Interfaces.Repostiory;
using AirbnbCloneBackend.Application.Interfaces.Service;
using AirbnbCloneBackend.Domain.Models;
using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Text;

namespace AirbnbCloneBackend.Application.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly IPropertyRepository _repo;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public PropertyService(IPropertyRepository repo, IHttpContextAccessor httpContextAccessor) 
        {
            _repo = repo;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<PropertyResponseDto> CreateAsync(CreatePropertyRequestDto request, Guid userId, IFormFile file)
        {
            
            if (file == null || file.Length == 0) throw new ArgumentException("Property Image is required..");

            // Property Image Creation Started
            var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "properties");

            Directory.CreateDirectory(uploadFolder);

            var extentions = Path.GetExtension(file.FileName);

            // Save every image with unique file name with GUID
            var fileName = $"{Guid.NewGuid()}{extentions}";

            // Path to save instead of cloud for quick setup
            var filePath = Path.Combine(uploadFolder, fileName);

            
            await using var stream = new FileStream(filePath,FileMode.Create);

            // File Creating.. with mentioned path, and filename
            await file.CopyToAsync(stream);

            //Generate the URL
            var imageUrl = $"{_httpContextAccessor.HttpContext!.Request.Scheme}://" +
               $"{_httpContextAccessor.HttpContext.Request.Host}" +
               $"/uploads/properties/{fileName}";

            // Property Image Creation End

            var property = new Property
            {
                PropertyName = request.PropertyName,
                Description = request.Description,
                Location = request.Location,
                Price = request.Price,
                FileName = fileName,
                Status = true,
                CreatedAt = DateTime.UtcNow,
                UserId = userId
            };

            await _repo.CreateAsync(property);

            return MapToResponse(property);
        }

        public async Task<PagedList<PropertyResponseDto>> GetAllAsync(PropertyQuery request)
        {
            var result = await _repo.GetAllAsync(request);

            var items = result.Items.Select(MapToResponse).ToList();

            return new PagedList<PropertyResponseDto>(items, result.TotalItems);

        }

        public async Task<PropertyResponseDto?> GetByIdAsync(int id)
        {
            var property = await _repo.GetByIdAsync(id);

            if (property == null) return null;

            return MapToResponse(property);
        }

        public async Task<bool> UpdateAsync(int id, UpdatePropertyRequestDto request)
        {
            var property = await _repo.GetByIdAsync(id);

            if (property == null) return false;

            var updateProperty = new Property
            {
                Id = id,
                PropertyName = request.PropertyName,
                Location = request.Location,
                Description = request.Description,
                Price = request.Price,
                Status = property.Status,
                UserId = property.UserId,
                FileName = property.FileName,
                CreatedAt = property.CreatedAt,
                ModifiedAt = DateTime.UtcNow,
            };

            await _repo.UpdateAsync(updateProperty);

            return true;
        }

        public async Task<bool> UpdateStatusAsync(int id, bool status)
        {
            var property = await _repo.GetByIdAsync(id);

            if (property == null) return false;

            var updateProperty = new Property
            {
                Id = id,
                PropertyName = property.PropertyName,
                Location = property.Location,
                Description = property.Description,
                Price = property.Price,
                Status = status,
                FileName = property.FileName,
                UserId = property.UserId,
                CreatedAt = property.CreatedAt,
                ModifiedAt = DateTime.UtcNow,
            };

            await _repo.UpdateAsync(updateProperty);

            return true;
        }

        private PropertyResponseDto MapToResponse(Property property)
        {
            var imageUrl =
                $"{_httpContextAccessor.HttpContext!.Request.Scheme}://" +
                $"{_httpContextAccessor.HttpContext.Request.Host}" +
                $"/uploads/properties/{property.FileName}";

            return new PropertyResponseDto(
                property.Id,
                property.PropertyName,
                property.Location,
                property.Description,
                property.FileName,
                imageUrl,
                property.Price,
                property.Status
            );
        }
    }
}
