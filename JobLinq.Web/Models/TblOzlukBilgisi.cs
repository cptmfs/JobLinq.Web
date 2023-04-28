using System;
using System.Collections.Generic;

namespace JobLinq.Web.Models;

public partial class TblOzlukBilgisi
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string? Ad { get; set; }

    public string? Soyad { get; set; }

    public DateTime? DogumTarihi { get; set; }

    public int? Sehir { get; set; }

    public string? CepNo { get; set; }

    public string? SirketAdi { get; set; }

    public string? Tecrube { get; set; }

    public string? EgitimSeviyesi { get; set; }

    public string? Pozisyon { get; set; }

    public string? Okul { get; set; }

    public string? Bolum { get; set; }

    public string? Onyazi { get; set; }

    public virtual ICollection<Junction> Junctions { get; set; } = new List<Junction>();

    public virtual PrmSehir? SehirNavigation { get; set; }

    public virtual TblDatUser? User { get; set; }
}
