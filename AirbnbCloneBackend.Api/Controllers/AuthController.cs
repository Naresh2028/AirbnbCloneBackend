using AirbnbCloneBackend.Application.Dtos.Auth;
using AirbnbCloneBackend.Application.Interfaces.Auth;
using AirbnbCloneBackend.Application.Interfaces.Repostiory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AirbnbCloneBackend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _service;
        public AuthController(IAuthService service) 
        {
            _service = service;
        }
        [HttpPost("signup")]
        public async Task<ActionResult<bool>> SignUp(SignupRequest request) 
        {
            var result = await _service.SignupAsync(request);

            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponseDto>> LoginAsync(LoginRequestDto request) 
        {
            var result = await _service.LoginAsync(request);

            return Ok(result);
        }

    }
}
