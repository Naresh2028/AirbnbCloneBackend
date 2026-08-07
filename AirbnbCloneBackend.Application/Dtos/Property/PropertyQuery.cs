using System;
using System.Collections.Generic;
using System.Text;

namespace AirbnbCloneBackend.Application.Dtos.Property
{
    public record PropertyQuery(int PageNumber, int PageSize, string? SearchQuery, bool? Status);
}
