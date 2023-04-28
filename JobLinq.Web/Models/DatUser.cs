using System;
using System.Collections.Generic;

namespace JobLinq.Web.Models;

public partial class DatUser
{
    public int UserId { get; set; }

    public string? UserEmail { get; set; }

    public string? UserPassword { get; set; }

    public string? UserAccountType { get; set; }

    public virtual ICollection<DatOzluk> DatOzluks { get; set; } = new List<DatOzluk>();

    public virtual ICollection<DatSirket> DatSirkets { get; set; } = new List<DatSirket>();

    public virtual ICollection<JnkBasvuru> JnkBasvurus { get; set; } = new List<JnkBasvuru>();
}
