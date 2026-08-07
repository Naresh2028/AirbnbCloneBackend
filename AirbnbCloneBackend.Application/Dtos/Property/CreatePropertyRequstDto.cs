using System;
using System.Collections.Generic;
using System.Text;

namespace AirbnbCloneBackend.Application.Dtos.Property
{
    public record CreatePropertyRequestDto(string PropertyName, string Location,string Description,decimal Price);
}
