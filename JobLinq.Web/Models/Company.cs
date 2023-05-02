using System;
using System.Collections.Generic;

namespace JobLinq.Web.Models
{
    public partial class Company
    {
        public int CompanyId { get; set; }
        public int? UserId { get; set; }
        public string? Cname { get; set; }
        public byte? SectorId { get; set; }
        public string? Cadress { get; set; }
        public byte? CityId { get; set; }
    }
}
