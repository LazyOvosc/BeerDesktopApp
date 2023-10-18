using System;
using System.Collections.Generic;

namespace SipBiteUnite.Models;

public partial class Rating
{
    public int Id { get; set; }

    public int IdBeer { get; set; }

    public int IdFood { get; set; }

    public float Rating1 { get; set; }

    public int IdUser { get; set; }

    public virtual Beer? IdBeerNavigation { get; set; }

    public virtual Food? IdFoodNavigation { get; set; }

    public virtual User? IdUserNavigation { get; set; }
}
