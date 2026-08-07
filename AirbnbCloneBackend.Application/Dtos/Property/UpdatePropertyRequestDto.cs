using System;
using System.Collections.Generic;
using System.Text;

namespace AirbnbCloneBackend.Application.Dtos.Property
{
    // To Update existing record
    public record UpdatePropertyRequestDto(string PropertyName, string Location, string Description, decimal Price);
}
