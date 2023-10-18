using System;
using System.Collections.Generic;

namespace SipBiteUnite.Models;

public partial class Beer
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Type { get; set; }

    public string? Producer { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();

    public virtual ICollection<Shopssum> Shopssums { get; set; } = new List<Shopssum>();
}
