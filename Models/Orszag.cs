using System;
using System.Collections.Generic;

namespace Ivadi_Zs_Beckend_ES.Models;

public partial class Orszag
{
    public string Id { get; set; } = null!;

    public string? OrszagNev { get; set; }

    public virtual ICollection<Versenyzo> Versenyzos { get; set; } = new List<Versenyzo>();
}
