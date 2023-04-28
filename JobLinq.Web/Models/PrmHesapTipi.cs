using System;
using System.Collections.Generic;

namespace JobLinq.Web.Models;

public partial class PrmHesapTipi
{
    public int Id { get; set; }

    public string? HesapTipi { get; set; }

    public virtual ICollection<TblDatUser> TblDatUsers { get; set; } = new List<TblDatUser>();
}
