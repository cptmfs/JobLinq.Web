using System;
using System.Collections.Generic;

namespace JobLinq.Web.Models
{
    public partial class Candidate
    {
        public int CandidateId { get; set; }
        public int? UserId { get; set; }
        public string? Fname { get; set; }
        public string? Lname { get; set; }
        public DateTime? BirthDate { get; set; }
        public byte? CityId { get; set; }
        public string? Gsmno { get; set; }
    }
}
