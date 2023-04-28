using System;
using System.Collections.Generic;

namespace JobLinq.Web.Models;

public partial class DatSirket
{
    public int SirketId { get; set; }

    public int? UserId { get; set; }

    public string? SirketAdi { get; set; }

    public int? SektorId { get; set; }

    public string? SirketAdres { get; set; }

    public int? SehirId { get; set; }

    public virtual ICollection<DatIlan> DatIlans { get; set; } = new List<DatIlan>();

    public virtual PrmSehir? Sehir { get; set; }

    public virtual PrmSektorBilgisi? Sektor { get; set; }

    public virtual DatUser? User { get; set; }
}
