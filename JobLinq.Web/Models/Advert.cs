using System;
using System.Collections.Generic;

namespace JobLinq.Web.Models
{
    public partial class Advert
    {
        public int AdvertId { get; set; }
        public int? CompanyId { get; set; }
        public string? AdvertTitle { get; set; }
        public string? AdvertDetail { get; set; }
        public byte? CityId { get; set; }
        public string? JobType { get; set; }
    }
}
