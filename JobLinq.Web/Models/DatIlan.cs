using System;
using System.Collections.Generic;

namespace JobLinq.Web.Models;

public partial class DatIlan
{
    public int IlanId { get; set; }

    public int? SirketId { get; set; }

    public string? IlanBaslik { get; set; }

    public string? IlanDetay { get; set; }

    public int? SehirId { get; set; }

    public string? IsTip { get; set; }

    public virtual ICollection<JnkBasvuru> JnkBasvurus { get; set; } = new List<JnkBasvuru>();

    public virtual PrmSehir? Sehir { get; set; }

    public virtual DatSirket? Sirket { get; set; }
}
