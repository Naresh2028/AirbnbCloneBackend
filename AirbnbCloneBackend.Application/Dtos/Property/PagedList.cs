using AirbnbCloneBackend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirbnbCloneBackend.Application.Dtos.Property
{
    public record PagedList<T>(IEnumerable<T> Items, int TotalItems);
}
