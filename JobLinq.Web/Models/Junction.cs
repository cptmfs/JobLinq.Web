using System;
using System.Collections.Generic;

namespace JobLinq.Web.Models;

public partial class Junction
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? IlanId { get; set; }

    public virtual Tblilan? Ilan { get; set; }

    public virtual TblOzlukBilgisi? User { get; set; }
}
