using AirbnbCloneBackend.Application.Dtos.Property;
using AirbnbCloneBackend.Application.Interfaces.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AirbnbCloneBackend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyService _service;

        public PropertyController(IPropertyService service) 
        {
            _service = service;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PropertyResponseDto>> GetByIdAsync(int id) 
        {
            var result = await _service.GetByIdAsync(id);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<PagedList<PropertyResponseDto>>> GetAllAsync([FromQuery] PropertyQuery request) 
        {
            var lists = await _service.GetAllAsync(request);

            return Ok(lists);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromForm] CreatePropertyRequestDto request,[FromForm] IFormFile file) 
        {
            var  userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var created = await _service.CreateAsync(request, userId, file);

            return Ok(created);
        }

        [HttpPut("{id:int}/update")]
        public async Task<ActionResult> UpdateAsync(int id, UpdatePropertyRequestDto request) 
        {
            var updated = await _service.UpdateAsync(id,request);

            if (updated == false) { return NotFound(); }

            return NoContent();
        }

        [HttpPatch]
        public async Task<ActionResult> UpdateStatusAsync([FromBody] UpdatePropertyStatusRequestDto request)
        {
            var updated = await _service.UpdateStatusAsync(request.Id, request.Status);

            if (updated == false) { return NotFound(); }

            return NoContent();
        }
    }
}
