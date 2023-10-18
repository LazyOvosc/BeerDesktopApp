using System;
using System.Collections.Generic;

namespace SipBiteUnite.Models;

public partial class User
{
    public int Id { get; set; }

    public bool? IsLogined { get; set; }

    public string? Name { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();
}
