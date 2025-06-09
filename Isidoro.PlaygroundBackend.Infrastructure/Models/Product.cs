using System;
using System.Collections.Generic;

namespace Isidoro.PlaygroundBackend.Infrastructure.Models;

public partial class Product
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public decimal? Price { get; set; }
}
