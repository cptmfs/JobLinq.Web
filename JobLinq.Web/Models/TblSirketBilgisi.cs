using System;
using System.Collections.Generic;

namespace JobLinq.Web.Models;

public partial class TblSirketBilgisi
{
    public int SirketId { get; set; }

    public int? UserId { get; set; }

    public string? Ad { get; set; }

    public int? Sektor { get; set; }

    public string? Adres { get; set; }

    public int? Sehir { get; set; }

    public int? CalisanSayisi { get; set; }

    public string? Aciklama { get; set; }

    public virtual PrmSehir? SehirNavigation { get; set; }

    public virtual PrmSektorBilgisi? SektorNavigation { get; set; }

    public virtual TblDatUser? User { get; set; }
}
