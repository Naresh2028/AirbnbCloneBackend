using System;
using System.Collections.Generic;
using System.Text;

namespace AirbnbCloneBackend.Application.Dtos.Property
{
    // Soft delete
    public record UpdatePropertyStatusRequestDto(int Id, bool Status);
}
