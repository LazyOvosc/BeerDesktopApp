using System;
using System.Collections.Generic;

namespace SipBiteUnite.Models;

public partial class Shopssum
{
    public int ShopId { get; set; }

    public int BeerId { get; set; }

    public decimal? Price { get; set; }

    public string? Url { get; set; }

    public virtual Beer Beer { get; set; } = null!;

    public virtual Shop Shop { get; set; } = null!;
}
