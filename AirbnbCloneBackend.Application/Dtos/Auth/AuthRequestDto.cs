using System;
using System.Collections.Generic;
using System.Text;

namespace AirbnbCloneBackend.Application.Dtos.Auth
{
    public record SignupRequest(string Name, string Email, string Password);

}
