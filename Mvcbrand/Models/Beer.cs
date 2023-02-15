using System;
using System.Collections.Generic;

namespace Mvcbrand.Models;

public partial class Beer
{
    public decimal BeerId { get; set; }

    public string? Name { get; set; }

    public decimal? BrandId { get; set; }

    public virtual Brand? Brand { get; set; }
}
