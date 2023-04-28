using System;
using System.Collections.Generic;

namespace JobLinq.Web.Models;

public partial class PrmSektorBilgisi
{
    public int SektorId { get; set; }

    public string? SektorName { get; set; }

    public virtual ICollection<DatSirket> DatSirkets { get; set; } = new List<DatSirket>();

    public virtual ICollection<TblSirketBilgisi> TblSirketBilgisis { get; set; } = new List<TblSirketBilgisi>();
}
