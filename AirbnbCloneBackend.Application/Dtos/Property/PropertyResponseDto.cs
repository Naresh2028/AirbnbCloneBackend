using System;
using System.Collections.Generic;
using System.Text;

namespace AirbnbCloneBackend.Application.Dtos.Property
{
    public record PropertyResponseDto(int Id, string PropertyName, string Location, string Description, string fileName, string ImageUrl, decimal Price, bool Status);
}
