using System;
using System.Collections.Generic;

namespace JobLinq.Web.Models;

public partial class DatOzluk
{
    public int OzlukId { get; set; }

    public int? UserId { get; set; }

    public string? UserAd { get; set; }

    public string? UserSoyad { get; set; }

    public string? DoğumTarihi { get; set; }

    public int? SehirId { get; set; }

    public string? Gsmno { get; set; }

    public virtual DatUser? User { get; set; }
}
