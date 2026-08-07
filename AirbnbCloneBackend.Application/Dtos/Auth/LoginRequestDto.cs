using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AirbnbCloneBackend.Application.Dtos.Auth
{
    public record LoginRequestDto([Required]string Email, [Required]string Password);
    
}
