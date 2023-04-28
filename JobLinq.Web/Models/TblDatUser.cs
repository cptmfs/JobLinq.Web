using System;
using System.Collections.Generic;

namespace JobLinq.Web.Models;

public partial class TblDatUser
{
    public int UserId { get; set; }

    public string? Email { get; set; }

    public string? Parola { get; set; }

    public int? HesapTipi { get; set; }

    public virtual PrmHesapTipi? HesapTipiNavigation { get; set; }

    public virtual ICollection<TblOzlukBilgisi> TblOzlukBilgisis { get; set; } = new List<TblOzlukBilgisi>();

    public virtual ICollection<TblSirketBilgisi> TblSirketBilgisis { get; set; } = new List<TblSirketBilgisi>();
}
