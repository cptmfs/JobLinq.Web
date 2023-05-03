﻿using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace JobLinq.Web.Models
{
    public partial class Company
    {
        [DisplayName("Şirket ID")]
        public int CompanyId { get; set; }
        [DisplayName("Kullanıcı ID")]
        public int? UserId { get; set; }
        [DisplayName("Şirket Adı")]
        public string? Cname { get; set; }
        [DisplayName("Sektör ID")]
        public byte? SectorId { get; set; }
        [DisplayName("Şirket Adresi")]
        public string? Cadress { get; set; }
        [DisplayName("Şehir ID")]
        public byte? CityId { get; set; }
    }
}
