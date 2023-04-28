using System;
using System.Collections.Generic;

namespace JobLinq.Web.Models;

public partial class PrmSehir
{
    public int SehirId { get; set; }

    public string? SehirAdi { get; set; }

    public virtual ICollection<DatIlan> DatIlans { get; set; } = new List<DatIlan>();

    public virtual ICollection<DatSirket> DatSirkets { get; set; } = new List<DatSirket>();

    public virtual ICollection<TblOzlukBilgisi> TblOzlukBilgisis { get; set; } = new List<TblOzlukBilgisi>();

    public virtual ICollection<TblSirketBilgisi> TblSirketBilgisis { get; set; } = new List<TblSirketBilgisi>();
}
