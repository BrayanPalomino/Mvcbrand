using System;
using System.Collections.Generic;

namespace Mvcbrand.Models;

public partial class Brand
{
    public decimal BrandId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Beer> Beers { get; } = new List<Beer>();
}
