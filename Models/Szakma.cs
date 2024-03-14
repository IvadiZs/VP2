using System;
using System.Collections.Generic;

namespace Ivadi_Zs_Beckend_ES.Models;

public partial class Szakma
{
    public string Id { get; set; } = null!;

    public string? SzakmaNev { get; set; }

    public virtual ICollection<Versenyzo> Versenyzos { get; set; } = new List<Versenyzo>();
}
