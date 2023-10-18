using System;
using System.Collections.Generic;

namespace SipBiteUnite.Models;

public partial class Food
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Category { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();
}
