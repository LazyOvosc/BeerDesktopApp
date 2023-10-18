using System;
using System.Collections.Generic;

namespace SipBiteUnite.Models;

public partial class Shop
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Shopssum> Shopssums { get; set; } = new List<Shopssum>();
}
