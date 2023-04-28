using System;
using System.Collections.Generic;

namespace JobLinq.Web.Models;

public partial class JnkBasvuru
{
    public int BasvuruId { get; set; }

    public int? UserId { get; set; }

    public int? IlanId { get; set; }

    public virtual DatIlan? Ilan { get; set; }

    public virtual DatUser? User { get; set; }
}
